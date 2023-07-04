using FluentValidation;
using MediatR;
using Shared.Result;
using System.Net;

namespace Application.Behaviors;
public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse> where TResponse : ResultBase
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

        var validationResults =
            await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var errorDetails = validationResults
            .SelectMany(result => result.Errors)
            .Where(failure => failure != null)
            .Select(failure => new ErrorDetail(failure.PropertyName.Split('.').First(), failure.ErrorMessage))
            .Distinct()
            .ToArray();

        if (errorDetails.Any())
        {
            return CreateValidationResult<TResponse>(errorDetails);
        }

        return await next();
    }

    private static TResult CreateValidationResult<TResult>(ErrorDetail[] errorDetails)
        where TResult : ResultBase
    {
        return (TResult)Activator.CreateInstance(typeof(TResult), HttpStatusCode.BadRequest, null, errorDetails)!;
    }
}