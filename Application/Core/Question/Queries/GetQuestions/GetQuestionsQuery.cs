using MediatR;
using Shared.DTOs.Question;

namespace Application.Core.Question.Queries.GetQuestions;
public sealed record GetQuestionsQuery(string SearchTerm) : IRequest<IEnumerable<QuestionWithIdDTO>>;
