using MediatR;

namespace Application.Core.Quiz.Commands.DeleteQuiz;
public sealed record DeleteQuizCommand(int QuizId) : IRequest<Unit>;
