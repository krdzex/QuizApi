using Application.Core.Quiz.Commands.CreateQuiz;
using Application.Core.Quiz.Queries.GetQuizWithQuestions;
using Application.Core.Quiz.Queries.GetQuizzes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.Question;

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
    public async Task<IActionResult> GetAllQuizzes(CancellationToken cancellationToken)
    {
        var query = new GetQuizzesQuery();

        var response = await _sender.Send(query, cancellationToken);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetQuizById(int id, CancellationToken cancellationToken)
    {
        var query = new GetQuizWithQuestionsQuery(id);

        var response = await _sender.Send(query, cancellationToken);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateQuiz([FromBody] QuizCreateDTO quizCreate, CancellationToken cancellationToken)
    {
        var query = new CreateQuizCommand(quizCreate);

        var response = await _sender.Send(query, cancellationToken);

        return Ok(response);
    }
}
