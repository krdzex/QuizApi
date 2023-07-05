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


        var errorDetails = _validators
            .Select(validator => validator.Validate(request))
            .SelectMany(validationResult => validationResult.Errors)
            .Where(validationFailure => validationFailure is not null)
            .Select(failure => new ErrorDetail(
                failure.PropertyName,
                failure.ErrorMessage))
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