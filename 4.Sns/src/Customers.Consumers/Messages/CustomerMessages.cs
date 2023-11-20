using MediatR;

namespace Customers.Consumers.Messages;

public record CustomerCreated : ISqsMessage
{
    public required Guid Id { get; init; }
    public required string FullName { get; init; }
    public required string Email { get; init; }
    public required string GithubUsername { get; init; }
    public required DateTime DateOfBirth { get; init; }
}

public record CustomerUpdated : ISqsMessage
{
    public required Guid Id { get; init; }
    public required string FullName { get; init; }
    public required string Email { get; init; }
    public required string GithubUsername { get; init; }
    public required DateTime DateOfBirth { get; init; }
}

public record CustomerDeleted : ISqsMessage
{
    public required Guid Id { get; init; }
}