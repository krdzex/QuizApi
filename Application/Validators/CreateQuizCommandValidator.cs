using Application.Core.Quiz.Commands.CreateQuiz;
using FluentValidation;

namespace Application.Validators;
public sealed class CreateQuizCommandValidator :
    AbstractValidator<CreateQuizCommand>
{
    public CreateQuizCommandValidator()
    {
        RuleFor(q => q.QuizCreate.Name)
            .NotEmpty()
                .WithMessage("Quiz name is required")
            .MaximumLength(100)
                .WithMessage("Max number of characters is 100");

        RuleFor(x => x.QuizCreate.NewQuestions)
            .NotEmpty()
            .WithMessage("At least one new question is required");

        RuleForEach(x => x.QuizCreate.NewQuestions).ChildRules(questionRules =>
        {
            questionRules.RuleFor(q => q.Text)
                .NotEmpty()
                    .WithMessage("Text is required")
                .MaximumLength(1000)
                    .WithMessage("Max number of characters is 100");

            questionRules.RuleFor(q => q.Answer)
                .NotEmpty()
                    .WithMessage("Answer is required")
                .MaximumLength(1000)
                    .WithMessage("Max number of characters is 100");
        });

        RuleFor(u => u.QuizCreate.ExistingQuestionIds)
            .Custom((existingQuestionIds, context) =>
            {
                if (existingQuestionIds is not null)
                {
                    if (ContainsDuplicates(existingQuestionIds))
                    {
                        context.AddFailure("Duplicate existing question is not allowed");
                    }
                }
            });
    }

    public bool ContainsDuplicates<T>(IEnumerable<T> ids)
    {
        HashSet<T> set = new();

        foreach (var id in ids)
        {
            if (!set.Add(id))
            {
                return true;
            }
        }

        return false;
    }
}
