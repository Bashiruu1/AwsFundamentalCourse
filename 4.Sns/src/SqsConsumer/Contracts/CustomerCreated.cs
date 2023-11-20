namespace SqsPublisher.Contracts;

// Ideally in it's own class library
public record CustomerCreated
{
    public required Guid Id { get; init; }
    public required string FullName { get; init; }
    public required string Email { get; init; }
    public required string GithubUsername { get; init; }
    public required DateTime DateOfBirth { get; init; }
}