using MediatR;
using Shared.Result;

namespace Application.Core.Quiz.Commands.RemoveQuestionFromQuiz;
public sealed record RemoveQuestionFromQuizCommand(int QuizId, int QuestionId) : IRequest<Result>;
