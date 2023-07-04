using Contracts;
using MediatR;

namespace Application.Core.Question.Commands.UpdateQuestion;
internal sealed class UpdateQuestionHandler : IRequestHandler<UpdateQuestionCommand, Unit>
{
    private readonly IRepositoryManager _repository;

    public UpdateQuestionHandler(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = await _repository.Question.GetQuestionById(request.QuestionId);

        if (question is null)
        {

        }

        question.Text = request.QuestionUpdate.Text;
        question.Answer = request.QuestionUpdate.Answer;

        return Unit.Value;
    }
}