using Application.Abstraction.Messaging;

namespace Application.Core.Quiz.Commands.DeleteQuiz;
public sealed record DeleteQuizCommand(int QuizId) : ICommand;
