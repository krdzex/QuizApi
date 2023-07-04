using Application.Abstraction.Messaging;
using Contracts;
using Shared.Result;

namespace Application.Core.Quiz.Commands.UpdateQuizName;
internal sealed class UpdateQuizNameHandler : ICommandHandler<UpdateQuizNameCommand>
{
    private readonly IRepositoryManager _repository;

    public UpdateQuizNameHandler(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(UpdateQuizNameCommand request, CancellationToken cancellationToken)
    {
        var quiz = await _repository.Quiz.GetQuizById(request.QuizId);

        if (quiz is null)
        {
            return Result.NotFound($"Quiz with id '{request.QuizId}' not found.");
        }

        quiz.Name = request.QuizNameUpdate.Name;

        return Result.Success();
    }
}