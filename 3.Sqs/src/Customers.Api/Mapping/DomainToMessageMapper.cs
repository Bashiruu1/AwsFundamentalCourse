using Customers.Api.Contracts.Messages;
using Customers.Api.Domain;

namespace Customers.Api.Mapping;

public static class DomainToMessageMapper
{
    public static CustomerCreated ToCustomerCreatedMessage(this Customer customer)
    {
        return new CustomerCreated
        {
            Id = customer.Id,
            GithubUsername = customer.GitHubUsername,
            FullName = customer.FullName,
            Email = customer.Email,
            DateOfBirth = customer.DateOfBirth
        };
    }
    
    public static CustomerUpdated ToCustomerUpdatedMessage(this Customer customer)
    {
        return new CustomerUpdated
        {
            Id = customer.Id,
            GithubUsername = customer.GitHubUsername,
            FullName = customer.FullName,
            Email = customer.Email,
            DateOfBirth = customer.DateOfBirth
        };
    }
}