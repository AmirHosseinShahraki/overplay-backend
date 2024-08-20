using FluentValidation;

namespace Api.Endpoints.Tags.CreateTag;

public class CreateTagValidator : AbstractValidator<CreateTagRequest>
{
    public CreateTagValidator()
    {
        RuleFor(t => t.Title)
            .NotEmpty()
            .MaximumLength(100)
            .MinimumLength(3);
    }
}