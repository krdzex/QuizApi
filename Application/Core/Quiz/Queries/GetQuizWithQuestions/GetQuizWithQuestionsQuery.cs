using MediatR;
using Shared.DTOs.Quiz;
using Shared.Result;

namespace Application.Core.Quiz.Queries.GetQuizWithQuestions;
public sealed record GetQuizWithQuestionsQuery(int QuizId) : IRequest<Result<QuizWithQuestionsDTO>>;