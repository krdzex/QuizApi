using Contracts;
using MediatR;
using Shared.DTOs.Quiz;
using Shared.Result;

namespace Application.Core.Quiz.Queries.GetQuizWithQuestions;
internal sealed class GetQuizWithQuestionsHandler : IRequestHandler<GetQuizWithQuestionsQuery, Result<QuizWithQuestionsDTO>>
{
    private readonly IRepositoryManager _repository;

    public GetQuizWithQuestionsHandler(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<Result<QuizWithQuestionsDTO>> Handle(GetQuizWithQuestionsQuery request, CancellationToken cancellationToken)
    {
        var quiz = await _repository.Quiz.GetQuizWithQuestionsAsync(request.QuizId, cancellationToken);

        if (quiz is null)
        {
            return Result<QuizWithQuestionsDTO>.NotFound($"Quiz with id '{request.QuizId}' not found.");
        }

        return quiz;
    }
}