using Customers.Consumers.Messages;
using MediatR;

namespace Customers.Consumers.Handlers;

public class CustomerUpdatedHandler: IRequestHandler<CustomerUpdated>
{
    private ILogger<CustomerUpdatedHandler> _logger;

    public CustomerUpdatedHandler(ILogger<CustomerUpdatedHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(CustomerUpdated request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(request.GithubUsername);
        return Unit.Task;
    }
}