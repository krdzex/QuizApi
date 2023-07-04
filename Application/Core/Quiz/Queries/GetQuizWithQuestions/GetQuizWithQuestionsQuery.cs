using Application.Abstraction.Messaging;
using Shared.DTOs.Quiz;

namespace Application.Core.Quiz.Queries.GetQuizWithQuestions;
public sealed record GetQuizWithQuestionsQuery(int QuizId) : IQuery<QuizWithQuestionsDTO>;