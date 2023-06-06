using System.Text.Json;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Options;

namespace Customers.Consumers;

public class QueueConsumerService : BackgroundService
{
    private readonly IAmazonSQS _sqs;
    private readonly IOptions<QueueSettings> _queueSettings;

    public QueueConsumerService(IAmazonSQS sqs, IOptions<QueueSettings> queueSettings)
    {
        _sqs = sqs;
        _queueSettings = queueSettings;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var queueUrlResponse = await _sqs.GetQueueUrlAsync("customers", stoppingToken);
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
                var messageType = message.MessageAttributes["MessageType"].StringValue;

                switch (messageType)
                {
                    case nameof(CustomerCreated):
                        var created = JsonSerializer.Deserialize<CustomerCreated>(message.Body);
                        break;
                    case nameof(CustomerUpdated):
                        var updated = JsonSerializer.Deserialize<CustomerUpdated>(message.Body);
                        break;
                    case nameof(CustomerDeleted):
                        var deleted = JsonSerializer.Deserialize<CustomerDeleted>(message.Body);
                        break;
                }
                Console.WriteLine($"Message Id: {message.MessageId}");
                Console.WriteLine($"Message Body: {message.Body}");

                await _sqs.DeleteMessageAsync(queueUrlResponse.QueueUrl, message.ReceiptHandle, stoppingToken);
            }
            await Task.Delay(3000);
        }
        
    }
}