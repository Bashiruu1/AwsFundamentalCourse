using System.Text.Json;
using Amazon.SQS;
using Amazon.SQS.Model;
using SqsPublisher.Contracts;

var sqsClient = new AmazonSQSClient();

var customer = new CustomerCreated
{
    Id = Guid.NewGuid(),
    Email = "ShadowTheHedgehog@gmail.com",
    FullName = "Shadow The Hedgehog",
    DateOfBirth = new DateTime(2000, 01, 01),
    GithubUsername = "IAmFasterThanSonic"
};

var queueUrlResponse = await sqsClient.GetQueueUrlAsync("customers");
var sendMessageRequest = new SendMessageRequest
{
    QueueUrl = queueUrlResponse.QueueUrl,
    MessageBody = JsonSerializer.Serialize(customer),
    MessageAttributes = new Dictionary<string, MessageAttributeValue>
    {
        {
            "MessageType", new MessageAttributeValue
            {
                DataType = "String",
                StringValue = nameof(CustomerCreated)
            }
        }
    }
};

var response = await sqsClient.SendMessageAsync(sendMessageRequest);
