using Contracts;
using MediatR;
using Shared.DTOs.Question;

namespace Application.Core.Question.Queries.GetQuestions;
internal sealed class GetQuestionsHandler : IRequestHandler<GetQuestionsQuery, IEnumerable<QuestionWithIdDTO>>
{
    private readonly IRepositoryManager _repository;

    public GetQuestionsHandler(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<QuestionWithIdDTO>> Handle(GetQuestionsQuery request, CancellationToken cancellationToken)
    {
        var questions = await _repository.Question.GetQuestions(request.SearchTerm, cancellationToken);

        return questions;
    }
}
