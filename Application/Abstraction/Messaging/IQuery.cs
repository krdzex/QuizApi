using MediatR;
using Shared.Result;

namespace Application.Abstraction.Messaging;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{ }
