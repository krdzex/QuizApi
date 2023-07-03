using MediatR;

namespace Application.Core.Quiz.Queries.GetQuizzes;
public sealed record GetQuizzesQuery() : IRequest<Unit>;
