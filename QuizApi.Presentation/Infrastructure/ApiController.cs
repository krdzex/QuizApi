using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Result;
using System.Text.RegularExpressions;

namespace QuizApi.Presentation.Infrastructure;

[ApiController]
public abstract class ApiController : ControllerBase
{
    protected readonly ISender Sender;

    protected ApiController(ISender sender) => Sender = sender;

    protected IActionResult HandleFailure(Result result)
    {
        switch (result)
        {
            case { IsSuccess: true }:
                throw new InvalidOperationException();
            default:
                return CreateProblemResult(result);
        }
    }

    protected IActionResult HandleFailure<T>(Result<T> result)
    {
        switch (result)
        {
            case { IsSuccess: true }:
                throw new InvalidOperationException();
            default:
                return CreateProblemResult(result);
        }
    }

    private IActionResult CreateProblemResult(ResultBase result)
    {
        var problemDetails = new ProblemDetails
        {
            Type = $"https://httpstatuses.com/{(int)result.StatusCode}",
            Title = SplitCamelCaseTitle(result.StatusCode.ToString()),
            Status = (int)result.StatusCode,
            Detail = result.ErrorMessage?.Message,
        };

        if (result.Errors?.Length > 0)
        {
            problemDetails.Extensions[nameof(result.Errors)] = result.Errors;
        }

        return StatusCode((int)result.StatusCode, problemDetails);
    }

    private static string SplitCamelCaseTitle(string title)
    {
        var regex = new Regex("(?<=[a-z])([A-Z])", RegexOptions.Compiled);
        return regex.Replace(title, " $1");
    }
}