using Application.Abstraction.Messaging;
using Shared.DTOs.Quiz;

namespace Application.Core.Quiz.Commands.CreateQuiz;
public sealed record CreateQuizCommand(QuizCreateDTO QuizCreate) : ICommand;
