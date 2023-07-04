using System.Net;

namespace Shared.Result;
public class Result : ResultBase
{
    private Result(HttpStatusCode httpStatusCode) : base(httpStatusCode)
    {
    }

    public Result(HttpStatusCode statusCode, ErrorMessage errorMessage, ErrorDetail[] errors)
        : base(statusCode, errorMessage, errors)
    {
    }

    public static Result NotFound(string message)
    {
        return new Result(HttpStatusCode.NotFound, new ErrorMessage(message), Array.Empty<ErrorDetail>());
    }

    public static Result BadRequest(string message)
    {
        return new Result(HttpStatusCode.BadRequest, new ErrorMessage(message), Array.Empty<ErrorDetail>());
    }

    public static Result Success()
    {
        return new Result(HttpStatusCode.NoContent);
    }
}
