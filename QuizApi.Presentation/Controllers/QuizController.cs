using Application.Core.Quiz.Queries.GetQuizWithQuestions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizApi.Presentation.Infrastructure;

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

    //[HttpGet]
    //public async Task<IActionResult> GetAllQuizzes(CancellationToken cancellationToken)
    //{
    //    var query = new GetQuizzesQuery();

    //    var response = await _sender.Send(query, cancellationToken);

    //    return Ok(response);
    //}

    [HttpGet("{id}")]
    public async Task<IActionResult> GetQuizById(int id, CancellationToken cancellationToken)
    {
        var query = new GetQuizWithQuestionsQuery(id);

        var response = await Sender.Send(query, cancellationToken);

        return response.IsSuccess ? Ok(response.Value) : HandleFailure(response);
    }

    //[HttpPost]
    //public async Task<IActionResult> CreateQuiz([FromBody] QuizCreateDTO quizCreate, CancellationToken cancellationToken)
    //{
    //    var command = new CreateQuizCommand(quizCreate);

    //    var response = await _sender.Send(command, cancellationToken);

    //    return NoContent();
    //}

    //[HttpDelete("{id}")]
    //public async Task<IActionResult> DeleteQuiz(int id, CancellationToken cancellationToken)
    //{
    //    var command = new DeleteQuizCommand(id);

    //    var response = await _sender.Send(command, cancellationToken);

    //    return NoContent();
    //}

    //[HttpPut("{id}/name")]
    //public async Task<IActionResult> DeleteQuiz(int id, QuizNameUpdateDTO quizNameUpdate, CancellationToken cancellationToken)
    //{
    //    var command = new UpdateQuizNameCommand(id, quizNameUpdate);

    //    var response = await _sender.Send(command, cancellationToken);

    //    return NoContent();
    //}

    //[HttpDelete("{quizId}/question/{questionId}")]

    //public async Task<IActionResult> DeleteQuestionFromQuiz(int quizId, int questionId, CancellationToken cancellationToken)
    //{
    //    var command = new RemoveQuestionFromQuizCommand(quizId, questionId);

    //    var response = await _sender.Send(command, cancellationToken);

    //    return NoContent();
    //}

    //[HttpGet("exporter")]
    //public async Task<IActionResult> GetAllExporters()
    //{
    //    var exporters = _exporterProvider.GetExporters();

    //    return Ok(exporters);
    //}

    //[HttpGet("{quizId}/exporter/{exportFormat}")]
    //public async Task<IActionResult> ExportQuiz(int quizId, string exportFormat, CancellationToken cancellationToken)
    //{
    //    var query = new GetQuizForExportQuery(quizId);

    //    var response = await _sender.Send(query, cancellationToken);

    //    var exporter = _exporterProvider.GetExporter(exportFormat);

    //    if (exporter == null)
    //    {
    //        return BadRequest("Invalid export format");
    //    }

    //    var exportedData = exporter.ExportAsync(response);

    //    return File(Encoding.UTF8.GetBytes(exportedData), "text/csv", $"{quizId}.csv");
    //}
}
