using Contracts;
using MediatR;

namespace Application.Core.Quiz.Commands.RemoveQuestionFromQuiz;
internal sealed class RemoveQuestionFromQuizHandler : IRequestHandler<RemoveQuestionFromQuizCommand, Unit>
{
    private readonly IRepositoryManager _repository;

    public RemoveQuestionFromQuizHandler(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(RemoveQuestionFromQuizCommand request, CancellationToken cancellationToken)
    {
        var quizExist = await _repository.Quiz.QuizExists(request.QuizId, cancellationToken);

        if (!quizExist)
        {

        }

        var questionExist = await _repository.Question.QuestionExists(request.QuestionId, cancellationToken);

        if (!questionExist)
        {

        }

        var removeResult = await _repository.Quiz.RemoveQuestionFromQuiz(request.QuizId, request.QuestionId, cancellationToken);

        if (!removeResult)
        {

        }

        await _repository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
