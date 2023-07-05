using Application.Abstraction.Messaging;
using Contracts;
using Shared.DTOs.Question;
using Shared.RequestFeatures;
using Shared.Result;

namespace Application.Core.Question.Queries.GetQuestions;
internal sealed class GetQuestionsHandler : IQueryHandler<GetQuestionsQuery, PagedList<QuestionDTO>>
{
    private readonly IRepositoryManager _repository;

    public GetQuestionsHandler(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<Result<PagedList<QuestionDTO>>> Handle(GetQuestionsQuery request, CancellationToken cancellationToken)
    {
        var questions = await _repository.Question.GetQuestions(request.QuestionParameters, cancellationToken);

        return questions;
    }
}
