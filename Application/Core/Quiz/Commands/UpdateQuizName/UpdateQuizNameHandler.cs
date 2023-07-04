using Contracts;
using MediatR;

namespace Application.Core.Quiz.Commands.UpdateQuizName;
internal sealed class UpdateQuizNameHandler : IRequestHandler<UpdateQuizNameCommand, Unit>
{
    private readonly IRepositoryManager _repository;

    public UpdateQuizNameHandler(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateQuizNameCommand request, CancellationToken cancellationToken)
    {
        var quiz = await _repository.Quiz.GetQuizById(request.QuizId);

        if (quiz is null)
        {

        }

        quiz.Name = request.QuizNameUpdate.Name;

        return Unit.Value;
    }
}