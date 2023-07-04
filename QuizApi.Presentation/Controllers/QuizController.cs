﻿using Application.Core.Quiz.Commands.CreateQuiz;
using Application.Core.Quiz.Commands.DeleteQuiz;
using Application.Core.Quiz.Commands.RemoveQuestionFromQuiz;
using Application.Core.Quiz.Commands.UpdateQuizName;
using Application.Core.Quiz.Queries.GetQuizForExport;
using Application.Core.Quiz.Queries.GetQuizWithQuestions;
using Application.Core.Quiz.Queries.GetQuizzes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.Quiz;
using System.Text;

namespace QuizApi.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuizController : ControllerBase
{
    private readonly ISender _sender;
    private readonly ExporterProvider _exporterProvider;

    public QuizController(ISender sender)
    {
        _sender = sender;
        _exporterProvider = new ExporterProvider();
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
        var command = new CreateQuizCommand(quizCreate);

        var response = await _sender.Send(command, cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteQuiz(int id, CancellationToken cancellationToken)
    {
        var command = new DeleteQuizCommand(id);

        var response = await _sender.Send(command, cancellationToken);

        return NoContent();
    }

    [HttpPut("{id}/name")]
    public async Task<IActionResult> DeleteQuiz(int id, QuizNameUpdateDTO quizNameUpdate, CancellationToken cancellationToken)
    {
        var command = new UpdateQuizNameCommand(id, quizNameUpdate);

        var response = await _sender.Send(command, cancellationToken);

        return NoContent();
    }

    [HttpDelete("{quizId}/question/{questionId}")]

    public async Task<IActionResult> DeleteQuestionFromQuiz(int quizId, int questionId, CancellationToken cancellationToken)
    {
        var command = new RemoveQuestionFromQuizCommand(quizId, questionId);

        var response = await _sender.Send(command, cancellationToken);

        return NoContent();
    }

    [HttpGet("exporter")]
    public async Task<IActionResult> GetAllExporters()
    {
        var exporters = _exporterProvider.GetExporters();

        return Ok(exporters);
    }

    [HttpGet("{quizId}/exporter/{exportFormat}")]
    public async Task<IActionResult> ExportQuiz(int quizId, string exportFormat, CancellationToken cancellationToken)
    {
        var query = new GetQuizForExportQuery(quizId);

        var response = await _sender.Send(query, cancellationToken);

        var exporter = _exporterProvider.GetExporter(exportFormat);

        if (exporter == null)
        {
            return BadRequest("Invalid export format");
        }

        var exportedData = exporter.ExportAsync(response);

        return File(Encoding.UTF8.GetBytes(exportedData), "text/csv", $"{quizId}.csv");
    }
}
