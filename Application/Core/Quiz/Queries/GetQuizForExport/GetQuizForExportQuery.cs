using MediatR;
using Shared.DTOs.Quiz;
using Shared.Result;

namespace Application.Core.Quiz.Queries.GetQuizForExport;
public sealed record GetQuizForExportQuery(int QuizId) : IRequest<Result<QuizWithQuestionTextDTO>>;