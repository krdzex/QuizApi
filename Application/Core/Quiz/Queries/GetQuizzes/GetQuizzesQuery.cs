using Application.Abstraction.Messaging;
using Shared.DTOs.Quiz;
using Shared.RequestFeatures;

namespace Application.Core.Quiz.Queries.GetQuizzes;
public sealed record GetQuizzesQuery(QuizParameters QuizParameters) : IQuery<PagedList<QuizNameDTO>>;
