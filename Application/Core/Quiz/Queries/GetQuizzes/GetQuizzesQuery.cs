using MediatR;
using Shared.DTOs.Quiz;
using Shared.Result;

namespace Application.Core.Quiz.Queries.GetQuizzes;
public sealed record GetQuizzesQuery() : IRequest<Result<List<QuizNameDTO>>>;
