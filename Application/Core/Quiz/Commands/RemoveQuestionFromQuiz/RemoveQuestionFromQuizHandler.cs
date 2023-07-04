using Contracts;
using MediatR;
using Shared.Result;

namespace Application.Core.Quiz.Commands.RemoveQuestionFromQuiz;
internal sealed class RemoveQuestionFromQuizHandler : IRequestHandler<RemoveQuestionFromQuizCommand, Result>
{
    private readonly IRepositoryManager _repository;

    public RemoveQuestionFromQuizHandler(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(RemoveQuestionFromQuizCommand request, CancellationToken cancellationToken)
    {
        var quizExist = await _repository.Quiz.QuizExists(request.QuizId, cancellationToken);

        if (!quizExist)
        {
            return Result.NotFound($"Quiz with id '{request.QuizId}' not found.");
        }

        var questionExist = await _repository.Question.QuestionExists(request.QuestionId, cancellationToken);

        if (!questionExist)
        {
            return Result.NotFound($"Question with id '{request.QuizId}' not found.");
        }

        var removeResult = await _repository.Quiz.RemoveQuestionFromQuiz(request.QuizId, request.QuestionId, cancellationToken);

        if (!removeResult)
        {
            return Result.BadRequest($"Remove question from quiz is not successfully done. Chack that question exist in quiz in order to remove it");
        }

        return Result.Success();
    }
}
