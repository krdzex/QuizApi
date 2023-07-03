using MediatR;
using Shared.DTOs.Quiz;

namespace Application.Core.Quiz.Queries.GetQuizWithQuestions;
public sealed record GetQuizWithQuestionsQuery(int QuizId) : IRequest<QuizWithQuestionsDTO>;