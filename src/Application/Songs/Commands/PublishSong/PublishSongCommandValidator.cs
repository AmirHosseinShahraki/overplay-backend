using FluentValidation;
using NAudio.Wave;

namespace Application.Songs.Commands.PublishSong;

public class PublishSongCommandValidator : AbstractValidator<PublishSongCommand>
{
    public PublishSongCommandValidator()
    {
        RuleFor(c => c.AudioFile)
            .Must(IsMP3)
            .WithMessage("The file is not a valid MP3 file");
    }

    private static bool IsMP3(Stream audioStream)
    {
        try
        {
            using Mp3FileReader reader = new(audioStream);
            return true;
        }
        catch
        {
            return false;
        }
    }
}