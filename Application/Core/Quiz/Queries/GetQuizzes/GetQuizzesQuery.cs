using Application.Abstraction.Messaging;
using Shared.DTOs.Quiz;

namespace Application.Core.Quiz.Queries.GetQuizzes;
public sealed record GetQuizzesQuery() : IQuery<List<QuizNameDTO>>;
