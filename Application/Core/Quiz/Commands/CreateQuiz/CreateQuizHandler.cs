﻿using Contracts;
using Entities.Models;
using MediatR;
using Shared.Result;

namespace Application.Core.Quiz.Commands.CreateQuiz;
internal sealed class CreateQuizHandler : IRequestHandler<CreateQuizCommand, Result>
{
    private readonly IRepositoryManager _repository;

    public CreateQuizHandler(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
    {
        var quiz = new Entities.Models.Quiz
        {
            Name = request.QuizCreate.Name,
            QuizQuestions = new List<QuizQuestion>()
        };

        foreach (var newQuestion in request.QuizCreate.NewQuestions)
        {
            quiz.QuizQuestions.Add(new QuizQuestion
            {
                Question = new Entities.Models.Question { Text = newQuestion.Text, Answer = newQuestion.Answer }
            });
        }

        foreach (var existingQuestionId in request.QuizCreate.ExistingQuestionIds)
        {
            var existingQuestion = await _repository.Question.GetQuestionById(existingQuestionId);

            if (existingQuestion is null)
            {
                return Result.NotFound($"Question with id '{existingQuestionId}' not found.");
            }

            quiz.QuizQuestions.Add(new QuizQuestion { QuestionId = existingQuestionId });
        }

        _repository.Quiz.Create(quiz);

        return Result.Success();
    }
}
