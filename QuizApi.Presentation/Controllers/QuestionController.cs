using Application.Core.Question.Commands.UpdateQuestion;
using Application.Core.Question.Queries.GetQuestions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizApi.Presentation.Infrastructure;
using Shared.DTOs.Question;

namespace QuizApi.Presentation.Controllers;

[Route("api/[controller]")]
public class QuestionController : ApiController
{
    public QuestionController(ISender sender)
        : base(sender)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetQuestions([FromQuery] string searchTerm, CancellationToken cancellationToken)
    {
        var query = new GetQuestionsQuery(searchTerm);

        var result = await Sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : HandleFailure(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> GetQuestions(int id, [FromBody] QuestionUpdateDTO questionUpdate, CancellationToken cancellationToken)
    {
        var command = new UpdateQuestionCommand(id, questionUpdate);

        var result = await Sender.Send(command, cancellationToken);

        return result.IsSuccess ? NoContent() : HandleFailure(result);
    }
}
