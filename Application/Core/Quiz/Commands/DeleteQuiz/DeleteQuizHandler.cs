using Application.Abstraction.Messaging;
using Contracts;
using Shared.Result;

namespace Application.Core.Quiz.Commands.DeleteQuiz;
internal sealed class DeleteQuizHandler : ICommandHandler<DeleteQuizCommand>
{
    private readonly IRepositoryManager _repository;

    public DeleteQuizHandler(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(DeleteQuizCommand request, CancellationToken cancellationToken)
    {
        var quiz = await _repository.Quiz.GetQuizById(request.QuizId);

        if (quiz is null)
        {
            return Result.NotFound($"Quiz with id '{request.QuizId}' not found.");
        }

        _repository.Quiz.Delete(quiz);

        return Result.Success();
    }
}
