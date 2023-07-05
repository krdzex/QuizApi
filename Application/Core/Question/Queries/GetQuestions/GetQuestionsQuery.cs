using Application.Abstraction.Messaging;
using Shared.DTOs.Question;
using Shared.RequestFeatures;

namespace Application.Core.Question.Queries.GetQuestions;
public sealed record GetQuestionsQuery(QuestionParameters QuestionParameters) : IQuery<PagedList<QuestionDTO>>;
