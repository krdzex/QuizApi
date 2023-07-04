using Application.Abstraction.Messaging;
using Contracts;
using Shared.Result;

namespace Application.Core.Question.Commands.UpdateQuestion;
internal sealed class UpdateQuestionHandler : ICommandHandler<UpdateQuestionCommand>
{
    private readonly IRepositoryManager _repository;

    public UpdateQuestionHandler(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = await _repository.Question.GetQuestionById(request.QuestionId);

        if (question is null)
        {
            return Result.NotFound($"Question with id '{request.QuestionId}' not found.");
        }

        question.Text = request.QuestionUpdate.Text;
        question.Answer = request.QuestionUpdate.Answer;

        return Result.Success();
    }
}