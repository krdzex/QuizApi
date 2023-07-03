using MediatR;
using Shared.DTOs.Quiz;

namespace Application.Core.Quiz.Queries.GetQuizzes;
public sealed record GetQuizzesQuery() : IRequest<IEnumerable<QuizNameDTO>>;
