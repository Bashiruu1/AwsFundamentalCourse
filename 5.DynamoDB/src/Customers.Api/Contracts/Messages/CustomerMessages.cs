namespace Customers.Api.Contracts.Messages;

public record CustomerCreated
{
    public required Guid Id { get; init; }
    public required string FullName { get; init; }
    public required string Email { get; init; }
    public required string GithubUsername { get; init; }
    public required DateTime DateOfBirth { get; init; }
}

public record CustomerUpdated
{
    public required Guid Id { get; init; }
    public required string FullName { get; init; }
    public required string Email { get; init; }
    public required string GithubUsername { get; init; }
    public required DateTime DateOfBirth { get; init; }
}

public record CustomerDelete
{
    public required Guid Id { get; init; }
}