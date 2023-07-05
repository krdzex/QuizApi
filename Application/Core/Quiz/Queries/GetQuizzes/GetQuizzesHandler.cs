using Application.Abstraction.Messaging;
using Contracts;
using Shared.DTOs.Quiz;
using Shared.RequestFeatures;
using Shared.Result;

namespace Application.Core.Quiz.Queries.GetQuizzes;
internal sealed class GetQuizzesHandler : IQueryHandler<GetQuizzesQuery, PagedList<QuizNameDTO>>
{
    private readonly IRepositoryManager _repository;

    public GetQuizzesHandler(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<Result<PagedList<QuizNameDTO>>> Handle(GetQuizzesQuery request, CancellationToken cancellationToken)
    {
        var quizzes = await _repository.Quiz.GetAllQuizNamesAsync(request.QuizParameters, cancellationToken);

        return quizzes;
    }
}