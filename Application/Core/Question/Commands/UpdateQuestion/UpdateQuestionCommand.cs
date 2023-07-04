using Application.Abstraction.Messaging;
using Shared.DTOs.Question;

namespace Application.Core.Question.Commands.UpdateQuestion;
public sealed record UpdateQuestionCommand(int QuestionId, QuestionUpdateDTO QuestionUpdate) : ICommand;