using MediatR;
using Shared.DTOs.Quiz;
using Shared.Result;

namespace Application.Core.Quiz.Commands.UpdateQuizName;
public sealed record UpdateQuizNameCommand(int QuizId, QuizNameUpdateDTO QuizNameUpdate) : IRequest<Result>;