using Contracts;
using MediatR;
using Shared.Result;

namespace Application.Core.Quiz.Commands.UpdateQuizName;
internal sealed class UpdateQuizNameHandler : IRequestHandler<UpdateQuizNameCommand, Result>
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