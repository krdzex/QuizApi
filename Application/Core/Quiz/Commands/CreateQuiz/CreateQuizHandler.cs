using Contracts;
using Entities.Models;
using MediatR;

namespace Application.Core.Quiz.Commands.CreateQuiz;
internal sealed class CreateQuizHandler : IRequestHandler<CreateQuizCommand, Unit>
{
    private readonly IRepositoryManager _repository;

    public CreateQuizHandler(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
    {
        var quiz = new Entities.Models.Quiz
        {
            Name = request.QuizCreate.Name,
            QuizQuestions = new List<QuizQuestion>()
        };

        foreach (var newQuestion in request.QuizCreate.NewQuestions)
        {
            quiz.QuizQuestions.Add(new QuizQuestion
            {
                Question = new Question { Text = newQuestion.Text, Answer = newQuestion.Answer }
            });
        }

        foreach (var existingQuestionId in request.QuizCreate.ExistingQuestionIds)
        {
            var existingQuestion = await _repository.Question.GetQuestionById(existingQuestionId);

            if (existingQuestion != null)
            {
                quiz.QuizQuestions.Add(new QuizQuestion { QuestionId = existingQuestionId });
            }
        }

        _repository.Quiz.Create(quiz);

        await _repository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
