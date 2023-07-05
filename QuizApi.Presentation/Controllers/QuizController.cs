using Application.Core.Quiz.Commands.CreateQuiz;
using Application.Core.Quiz.Commands.DeleteQuiz;
using Application.Core.Quiz.Commands.RemoveQuestionFromQuiz;
using Application.Core.Quiz.Commands.UpdateQuizName;
using Application.Core.Quiz.Queries.GetQuizForExport;
using Application.Core.Quiz.Queries.GetQuizWithQuestions;
using Application.Core.Quiz.Queries.GetQuizzes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizApi.Presentation.Infrastructure;
using Shared.DTOs.Quiz;
using Shared.RequestFeatures;
using System.Text;

namespace QuizApi.Presentation.Controllers;

[Route("api/[controller]")]
public class QuizController : ApiController
{
    private readonly ExporterProvider _exporterProvider;

    public QuizController(ISender sender)
        : base(sender)
    {
        _exporterProvider = new ExporterProvider();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllQuizzes([FromQuery] QuizParameters quizParameters, CancellationToken cancellationToken)
    {
        var query = new GetQuizzesQuery(quizParameters);

        var result = await Sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : HandleFailure(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetQuizById(int id, CancellationToken cancellationToken)
    {
        var query = new GetQuizWithQuestionsQuery(id);

        var result = await Sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : HandleFailure(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateQuiz([FromBody] QuizCreateDTO quizCreate, CancellationToken cancellationToken)
    {
        var command = new CreateQuizCommand(quizCreate);

        var result = await Sender.Send(command, cancellationToken);

        return result.IsSuccess ? NoContent() : HandleFailure(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteQuiz(int id, CancellationToken cancellationToken)
    {
        var command = new DeleteQuizCommand(id);

        var result = await Sender.Send(command, cancellationToken);

        return result.IsSuccess ? NoContent() : HandleFailure(result);
    }

    [HttpPut("{id}/name")]
    public async Task<IActionResult> DeleteQuiz(int id, QuizNameUpdateDTO quizNameUpdate, CancellationToken cancellationToken)
    {
        var command = new UpdateQuizNameCommand(id, quizNameUpdate);

        var result = await Sender.Send(command, cancellationToken);

        return result.IsSuccess ? NoContent() : HandleFailure(result);
    }

    [HttpDelete("{quizId}/question/{questionId}")]

    public async Task<IActionResult> DeleteQuestionFromQuiz(int quizId, int questionId, CancellationToken cancellationToken)
    {
        var command = new RemoveQuestionFromQuizCommand(quizId, questionId);

        var result = await Sender.Send(command, cancellationToken);

        return result.IsSuccess ? NoContent() : HandleFailure(result);
    }

    [HttpGet("exporter")]
    public IActionResult GetAllExporters()
    {
        var exporters = _exporterProvider.GetExporters();

        return Ok(exporters);
    }

    [HttpGet("{quizId}/exporter/{exportFormat}")]
    public async Task<IActionResult> ExportQuiz(int quizId, string exportFormat, CancellationToken cancellationToken)
    {
        var query = new GetQuizForExportQuery(quizId);

        var result = await Sender.Send(query, cancellationToken);

        if (!result.IsSuccess)
        {
            return HandleFailure(result);
        }
        var exporter = _exporterProvider.GetExporter(exportFormat);

        if (exporter == null)
        {
            return BadRequest("Invalid export format");
        }

        var exportedData = exporter.ExportAsync(result.Value);

        return File(Encoding.UTF8.GetBytes(exportedData), "text/csv", $"{quizId}.csv");
    }
}
