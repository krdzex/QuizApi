using Application.Core.Question.Commands.UpdateQuestion;
using Application.Core.Question.Queries.GetQuestions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.Question;

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

    [HttpPut("{id}")]
    public async Task<IActionResult> GetQuestions(int id, [FromBody] QuestionUpdateDTO questionUpdate, CancellationToken cancellationToken)
    {
        var command = new UpdateQuestionCommand(id, questionUpdate);

        var response = await _sender.Send(command, cancellationToken);

        return NoContent();
    }
}
