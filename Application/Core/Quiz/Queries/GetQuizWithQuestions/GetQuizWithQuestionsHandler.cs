using Contracts;
using MediatR;
using Shared.DTOs.Quiz;

namespace Application.Core.Quiz.Queries.GetQuizWithQuestions;
internal sealed class GetQuizWithQuestionsHandler : IRequestHandler<GetQuizWithQuestionsQuery, QuizWithQuestionsDTO>
{
    private readonly IRepositoryManager _repository;

    public GetQuizWithQuestionsHandler(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<QuizWithQuestionsDTO> Handle(GetQuizWithQuestionsQuery request, CancellationToken cancellationToken)
    {
        var quiz = await _repository.Quiz.GetQuizWithQuestionsAsync(request.QuizId, cancellationToken);

        return quiz;
    }
}