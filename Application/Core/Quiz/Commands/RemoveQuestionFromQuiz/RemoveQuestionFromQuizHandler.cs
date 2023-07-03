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

        var question = await _repository.Question.GetQuestionById(request.QuestionId);

        await _repository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
