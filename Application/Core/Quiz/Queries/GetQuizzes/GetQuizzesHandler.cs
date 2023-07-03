using Contracts;
using MediatR;
using Shared.DTOs.Quiz;

namespace Application.Core.Quiz.Queries.GetQuizzes;
internal sealed class GetQuizzesHandler : IRequestHandler<GetQuizzesQuery, IEnumerable<QuizNameDTO>>
{
    private readonly IRepositoryManager _repository;

    public GetQuizzesHandler(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<QuizNameDTO>> Handle(GetQuizzesQuery request, CancellationToken cancellationToken)
    {
        var quizzes = await _repository.Quiz.GetAllQuizNamesAsync(cancellationToken);

        return quizzes;
    }
}