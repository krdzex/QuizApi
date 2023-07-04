using Contracts;
using MediatR;
using Shared.DTOs.Quiz;
using Shared.Result;

namespace Application.Core.Quiz.Queries.GetQuizzes;
internal sealed class GetQuizzesHandler : IRequestHandler<GetQuizzesQuery, Result<List<QuizNameDTO>>>
{
    private readonly IRepositoryManager _repository;

    public GetQuizzesHandler(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<Result<List<QuizNameDTO>>> Handle(GetQuizzesQuery request, CancellationToken cancellationToken)
    {
        var quizzes = await _repository.Quiz.GetAllQuizNamesAsync(cancellationToken);

        return quizzes.ToList();
    }
}