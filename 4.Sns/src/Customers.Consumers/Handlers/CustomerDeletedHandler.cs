using Customers.Consumers.Messages;
using MediatR;

namespace Customers.Consumers.Handlers;

public class CustomerDeletedHandler: IRequestHandler<CustomerDeleted>
{
    private ILogger<CustomerDeletedHandler> _logger;

    public CustomerDeletedHandler(ILogger<CustomerDeletedHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(CustomerDeleted request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("requestId: {requestId}", request.Id);
        return Unit.Task;
    }
}