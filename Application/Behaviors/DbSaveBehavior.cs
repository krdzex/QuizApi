using Contracts;
using MediatR;
using System.Transactions;

namespace Application.Behaviors;

public sealed class DbSaveBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
{
    private readonly IRepositoryManager _repository;

    public DbSaveBehavior(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var isCommand = typeof(TRequest).Name.EndsWith("Command");

        if (!isCommand)
        {
            return await next();
        }

        using (var transactionScope = new TransactionScope())
        {
            var response = await next();

            await _repository.SaveAsync(cancellationToken);

            transactionScope.Complete();

            return response;
        }
    }
}