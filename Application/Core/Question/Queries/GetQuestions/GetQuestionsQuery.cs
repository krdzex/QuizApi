using Application.Abstraction.Messaging;
using Shared.DTOs.Question;

namespace Application.Core.Question.Queries.GetQuestions;
public sealed record GetQuestionsQuery(string SearchTerm) : IQuery<List<QuestionDTO>>;
