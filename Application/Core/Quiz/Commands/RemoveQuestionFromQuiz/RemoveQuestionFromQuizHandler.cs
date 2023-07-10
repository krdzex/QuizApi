using Application.Abstraction.Messaging;
using Contracts;
using Shared.Result;

namespace Application.Core.Quiz.Commands.RemoveQuestionFromQuiz;
internal sealed class RemoveQuestionFromQuizHandler : ICommandHandler<RemoveQuestionFromQuizCommand>
{
    private readonly IRepositoryManager _repository;

    public RemoveQuestionFromQuizHandler(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(RemoveQuestionFromQuizCommand request, CancellationToken cancellationToken)
    {
        var quiz = await _repository.Quiz.GetQuizByIdWithQuestions(request.QuizId, cancellationToken);

        if (quiz is null)
        {
            return Result.NotFound($"Quiz with id '{request.QuizId}' not found.");
        }

        var quizQuestion = _repository.Quiz.GetQuizQuestion(quiz, request.QuestionId);

        if (quizQuestion is null)
        {
            return Result.BadRequest("Failed to remove question. Please ensure the question exists in the quiz.");
        }

        quiz.QuizQuestions.Remove(quizQuestion);

        return Result.Success();
    }
}
