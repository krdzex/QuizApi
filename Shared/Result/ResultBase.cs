using System.Net;

namespace Shared.Result;
public abstract class ResultBase
{
    protected ResultBase(HttpStatusCode httpStatusCode)
    {
        IsSuccess = true;
        StatusCode = httpStatusCode;
    }

    protected ResultBase(HttpStatusCode statusCode, ErrorMessage errorMessage, ErrorDetail[] errors)
    {
        IsSuccess = false;
        StatusCode = statusCode;
        ErrorMessage = errorMessage;
        Errors = errors;
    }

    public bool IsSuccess { get; }

    public HttpStatusCode StatusCode { get; }

    public ErrorMessage? ErrorMessage { get; }

    public ErrorDetail[]? Errors { get; }

    public string GetErrorSummary()
    {
        return ErrorMessage?.Message
               ?? string.Join(Environment.NewLine, Errors!.Select(ed => $"{ed.Code}: {ed.Message}"));
    }
}