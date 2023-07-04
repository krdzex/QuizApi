using MediatR;
using Shared.DTOs.Question;
using Shared.Result;

namespace Application.Core.Question.Commands.UpdateQuestion;
public sealed record UpdateQuestionCommand(int QuestionId, QuestionUpdateDTO QuestionUpdate) : IRequest<Result>;