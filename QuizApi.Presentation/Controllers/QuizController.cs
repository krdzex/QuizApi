using Application.Core.Quiz.Queries.GetQuizzes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace QuizApi.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuizController : ControllerBase
{
    private readonly ISender _sender;

    public QuizController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var query = new GetQuizzesQuery();

        var response = await _sender.Send(query, cancellationToken);

        return Ok();
    }
}
