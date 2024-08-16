using FluentValidation;

namespace Api.Endpoints.Artists.CreateArtist;

public class CreateArtistRequestValidator : AbstractValidator<CreateArtistRequest>
{
    public CreateArtistRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100)
            .MinimumLength(3);
    }
}