using Contracts;
using MediatR;
using Shared.DTOs.Quiz;

namespace Application.Core.Quiz.Queries.GetQuizForExport;
internal sealed class GetQuizForExportHandler : IRequestHandler<GetQuizForExportQuery, QuizWithQuestionTextDTO>
{
    private readonly IRepositoryManager _repository;

    public GetQuizForExportHandler(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<QuizWithQuestionTextDTO> Handle(GetQuizForExportQuery request, CancellationToken cancellationToken)
    {
        var quiz = await _repository.Quiz.GetQuizForExport(request.QuizId, cancellationToken);

        if (quiz is null)
        {

        }

        return quiz;
    }
}