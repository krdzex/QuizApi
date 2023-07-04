using Contracts;
using MediatR;
using Shared.DTOs.Quiz;
using Shared.Result;

namespace Application.Core.Quiz.Queries.GetQuizForExport;
internal sealed class GetQuizForExportHandler : IRequestHandler<GetQuizForExportQuery, Result<QuizWithQuestionTextDTO>>
{
    private readonly IRepositoryManager _repository;

    public GetQuizForExportHandler(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<Result<QuizWithQuestionTextDTO>> Handle(GetQuizForExportQuery request, CancellationToken cancellationToken)
    {
        var quiz = await _repository.Quiz.GetQuizForExport(request.QuizId, cancellationToken);

        if (quiz is null)
        {
            return Result<QuizWithQuestionTextDTO>.NotFound($"Quiz with id '{request.QuizId}' not found.");
        }

        return quiz;
    }
}