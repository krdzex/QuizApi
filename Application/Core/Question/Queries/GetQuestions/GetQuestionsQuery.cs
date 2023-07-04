using MediatR;
using Shared.DTOs.Question;
using Shared.Result;

namespace Application.Core.Question.Queries.GetQuestions;
public sealed record GetQuestionsQuery(string SearchTerm) : IRequest<Result<List<QuestionDTO>>>;
