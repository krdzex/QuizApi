using Application.Abstraction.Messaging;
using Contracts;
using Entities.Models;
using Shared.Result;

namespace Application.Core.Quiz.Commands.AddQuestionToQuiz;
internal sealed class AddQuestionToQuizHandler : ICommandHandler<AddQuestionToQuizCommand>
{
    private readonly IRepositoryManager _repository;

    public AddQuestionToQuizHandler(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(AddQuestionToQuizCommand request, CancellationToken cancellationToken)
    {
        var quiz = await _repository.Quiz.GetQuizByIdWithQuestions(request.QuizId, cancellationToken);

        if (quiz is null)
        {
            return Result.NotFound($"Quiz with id '{request.QuizId}' not found.");
        }

        var question = await _repository.Question.GetQuestionById(request.QuestionId);

        if (question is null)
        {
            return Result.NotFound($"Question with id '{request.QuestionId}' not found.");
        }

        var questionExistsInQuiz = _repository.Quiz.QuestionExistInQuiz(quiz, request.QuestionId);

        if (questionExistsInQuiz)
        {
            return Result.BadRequest($"Question with id '{request.QuestionId}' already exists in quiz with id '{request.QuizId}'.");
        }

        quiz.QuizQuestions.Add(new QuizQuestion { QuestionId = request.QuestionId });

        return Result.Success();
    }
}