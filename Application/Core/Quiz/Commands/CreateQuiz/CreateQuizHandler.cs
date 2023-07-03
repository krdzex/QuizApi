﻿using Contracts;
using Entities.Models;
using MediatR;

namespace Application.Core.Quiz.Commands.CreateQuiz;
internal sealed class CreateQuizHandler : IRequestHandler<CreateQuizCommand, Unit>
{
    private readonly IRepositoryManager _repository;

    public CreateQuizHandler(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
    {
        var quiz = new Quiz
        {
            Name = request.QuizCreate.Name,
            QuizQuestions = new List<QuizQuestion>()
        };

        foreach (var newQuestion in request.QuizCreate.NewQuestions)
        {
            quiz.QuizQuestions.Add(new QuizQuestion
            {
                Question = new Question { Text = newQuestion.Text, Answer = newQuestion.Answer }
            });
        }

        _repository.Quiz.CreateQuiz(quiz);

        await _repository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
