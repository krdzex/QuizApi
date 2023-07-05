using Application.Core.Quiz.Commands.UpdateQuizName;
using FluentValidation;

namespace Application.Validators;
public sealed class UpdateQuizNameCommandValidator :
    AbstractValidator<UpdateQuizNameCommand>
{
    public UpdateQuizNameCommandValidator()
    {
        RuleFor(q => q.QuizNameUpdate.Name)
            .NotEmpty()
                .WithMessage("Quiz name is required")
            .MaximumLength(100)
                .WithMessage("Max number of characters is 100");

    }
}
