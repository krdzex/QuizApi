using Application.Abstraction.Messaging;

namespace Application.Core.Quiz.Commands.RemoveQuestionFromQuiz;
public sealed record RemoveQuestionFromQuizCommand(int QuizId, int QuestionId) : ICommand;
