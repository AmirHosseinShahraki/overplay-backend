using FluentValidation;

namespace Api.Endpoints.Songs.PublishSong;

public class PublishSongRequestValidator : AbstractValidator<PublishSongRequest>
{
    public PublishSongRequestValidator()
    {
        RuleFor(x => x.Title)
            .MaximumLength(100)
            .NotEmpty();
    }
}