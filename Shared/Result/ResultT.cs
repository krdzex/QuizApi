using System.Net;

namespace Shared.Result;
public class Result<T> : ResultBase
{
    private Result(T value, HttpStatusCode httpStatusCode) : base(httpStatusCode)
    {
        Value = value;
    }

    public Result(HttpStatusCode statusCode, ErrorMessage errorMessage, ErrorDetail[] errors)
        : base(statusCode, errorMessage, errors)
    {
    }

    public T? Value { get; }

    public static Result<T> NotFound(string message)
    {
        return new Result<T>(HttpStatusCode.NotFound, new ErrorMessage(message), Array.Empty<ErrorDetail>());
    }

    public static Result<T> BadRequest(string message)
    {
        return new Result<T>(HttpStatusCode.BadRequest, new ErrorMessage(message), Array.Empty<ErrorDetail>());
    }

    public static Result<T> Success(T value)
    {
        return new Result<T>(value, HttpStatusCode.OK);
    }

    public static implicit operator Result<T>(T value)
    {
        return Success(value);
    }
}
