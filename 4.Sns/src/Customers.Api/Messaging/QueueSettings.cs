namespace Customers.Api.Messaging;

public class QueueSettings
{
    public const string Key = nameof(QueueSettings);
    public required string Name { get; init; }
}