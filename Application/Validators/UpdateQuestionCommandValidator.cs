using Application.Core.Question.Commands.UpdateQuestion;
using FluentValidation;

namespace Application.Validators;
public sealed class UpdateQuestionCommandValidator :
    AbstractValidator<UpdateQuestionCommand>
{
    public UpdateQuestionCommandValidator()
    {
        RuleFor(q => q.QuestionUpdate.Text)
            .NotEmpty()
                .WithMessage("Question text is required")
            .MaximumLength(1000)
                .WithMessage("Max number of characters is 100");

        RuleFor(q => q.QuestionUpdate.Answer)
            .NotEmpty()
                .WithMessage("Question answer is required")
            .MaximumLength(1000)
                .WithMessage("Max number of characters is 100");
    }
}