using MediatR;
using Shared.Result;

namespace Application.Core.Quiz.Commands.DeleteQuiz;
public sealed record DeleteQuizCommand(int QuizId) : IRequest<Result>;
