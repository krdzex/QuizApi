using Contracts;
using MediatR;

namespace Application.Core.Quiz.Queries.GetQuizzes;
internal sealed class GetQuizzesHandler : IRequestHandler<GetQuizzesQuery, Unit>
{
    private readonly IRepositoryManager _repository;

    public GetQuizzesHandler(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(GetQuizzesQuery request, CancellationToken cancellationToken)
    {
        return Unit.Value;
    }
}