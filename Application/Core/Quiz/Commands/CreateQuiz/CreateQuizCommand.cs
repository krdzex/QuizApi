using MediatR;
using Shared.DTOs.Question;

namespace Application.Core.Quiz.Commands.CreateQuiz;
public sealed record CreateQuizCommand(QuizCreateDTO QuizCreate) : IRequest<Unit>;
