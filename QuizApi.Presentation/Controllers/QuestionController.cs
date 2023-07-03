using Application.Core.Question.Queries.GetQuestions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace QuizApi.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionController : ControllerBase
{
    private readonly ISender _sender;

    public QuestionController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetQuestions([FromQuery] string searchTerm, CancellationToken cancellationToken)
    {
        var query = new GetQuestionsQuery(searchTerm);

        var response = await _sender.Send(query, cancellationToken);

        return Ok(response);
    }
}
