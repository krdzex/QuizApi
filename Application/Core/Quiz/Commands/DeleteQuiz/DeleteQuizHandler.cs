using Contracts;
using MediatR;

namespace Application.Core.Quiz.Commands.DeleteQuiz;
internal sealed class DeleteQuizHandler : IRequestHandler<DeleteQuizCommand, Unit>
{
    private readonly IRepositoryManager _repository;

    public DeleteQuizHandler(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteQuizCommand request, CancellationToken cancellationToken)
    {
        var quiz = await _repository.Quiz.GetQuizById(request.QuizId);

        if (quiz is null)
        {

        }

        _repository.Quiz.Delete(quiz);

        return Unit.Value;
    }
}
