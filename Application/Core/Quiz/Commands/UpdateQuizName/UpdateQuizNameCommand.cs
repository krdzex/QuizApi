using MediatR;
using Shared.DTOs.Quiz;

namespace Application.Core.Quiz.Commands.UpdateQuizName;
public sealed record UpdateQuizNameCommand(int QuizId, QuizNameUpdateDTO QuizNameUpdate) : IRequest<Unit>;