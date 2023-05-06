using System.Text.Json;
using Amazon.SQS;
using Amazon.SQS.Model;
using SqsPublisher.Contracts;

var sqsClient = new AmazonSQSClient();

var customer = new CustomerCreated
{
    Id = Guid.NewGuid(),
    Email = "ShadowTheHedgehog@gmail.com",
    FullName = new Name
    {
        FirstName = "Shadow",
        LastName = "Hedgehog"
    },
    DateOfBirth = new DateTime(2000, 01, 01),
    GithubUsername = "IAmFasterThanSonic"
};

var queueUrlResponse = await sqsClient.GetQueueUrlAsync("customers");
var sendMessageRequest = new SendMessageRequest
{
    QueueUrl = queueUrlResponse.QueueUrl,
    MessageBody = JsonSerializer.Serialize(customer)
};

var response = await sqsClient.SendMessageAsync(sendMessageRequest);
