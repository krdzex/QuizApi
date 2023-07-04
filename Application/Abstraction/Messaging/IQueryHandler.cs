using MediatR;
using Shared.Result;

namespace Application.Abstraction.Messaging;
public interface IQueryHandler<TQuery, TResponse>
        : IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : IQuery<TResponse>
{ }
