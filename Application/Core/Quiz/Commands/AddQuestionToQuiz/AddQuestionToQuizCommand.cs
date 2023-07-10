using Application.Abstraction.Messaging;

namespace Application.Core.Quiz.Commands.AddQuestionToQuiz;
public sealed record AddQuestionToQuizCommand(int QuizId, int QuestionId) : ICommand;