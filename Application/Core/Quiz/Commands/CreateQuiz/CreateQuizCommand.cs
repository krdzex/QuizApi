using MediatR;
using Shared.DTOs.Quiz;
using Shared.Result;

namespace Application.Core.Quiz.Commands.CreateQuiz;
public sealed record CreateQuizCommand(QuizCreateDTO QuizCreate) : IRequest<Result>;
