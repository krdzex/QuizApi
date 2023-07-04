using Application.Abstraction.Messaging;
using Shared.DTOs.Quiz;

namespace Application.Core.Quiz.Queries.GetQuizForExport;
public sealed record GetQuizForExportQuery(int QuizId) : IQuery<QuizWithQuestionTextDTO>;