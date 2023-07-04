using MediatR;
using Shared.DTOs.Quiz;

namespace Application.Core.Quiz.Queries.GetQuizForExport;
public sealed record GetQuizForExportQuery(int QuizId) : IRequest<QuizWithQuestionTextDTO>;