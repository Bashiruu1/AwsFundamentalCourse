using System.Text.Json;
using Amazon.SQS;
using Amazon.SQS.Model;
using Customers.Consumers.Messages;
using MediatR;
using Microsoft.Extensions.Options;

namespace Customers.Consumers;

public class QueueConsumerService : BackgroundService
{
    private readonly IAmazonSQS _sqs;
    private readonly IOptions<QueueSettings> _queueSettings;
    private readonly IMediator _mediator;
    private readonly ILogger<QueueConsumerService> _logger;

    public QueueConsumerService(IAmazonSQS sqs, IOptions<QueueSettings> queueSettings, IMediator mediator, ILogger<QueueConsumerService> logger)
    {
        _sqs = sqs;
        _queueSettings = queueSettings;
        _mediator = mediator;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var queueUrlResponse = await _sqs.GetQueueUrlAsync(_queueSettings.Value.Name, stoppingToken);
        var recieveMessageRequest = new ReceiveMessageRequest
        {
            QueueUrl = queueUrlResponse.QueueUrl,
            AttributeNames = new List<string>{"All"},
            MessageAttributeNames = new List<string>{"All"},
            MaxNumberOfMessages = 1
        };
        
        
        while (!stoppingToken.IsCancellationRequested)
        {
            var response = await _sqs.ReceiveMessageAsync(recieveMessageRequest, stoppingToken);

            foreach (var message in response.Messages)
            {
                message.MessageAttributes.TryGetValue("MessageType", out var messageTypeString);
                var messageType = Type.GetType($"Customers.Consumers.Messages.{messageTypeString?.StringValue}");

                if (messageType is null)
                {
                    _logger.LogWarning("Unkwown message type: {messageTypeString}", messageTypeString);
                    continue;
                }

                var typedMessage = (ISqsMessage)JsonSerializer.Deserialize(message.Body, messageType)!;
                try
                {
                    await _mediator.Send(typedMessage, stoppingToken);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Message failed during processing");
                    continue;
                }
                await _sqs.DeleteMessageAsync(queueUrlResponse.QueueUrl, message.ReceiptHandle, stoppingToken);
            }
            await Task.Delay(3000);
        }
        
    }
}