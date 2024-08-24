using Application.Common.Interfaces;
using Domain.Entities;
using Domain.ValueObjects;
using MediatR;


namespace Application.Songs.Commands.PublishSong;

public class PublishSongCommand : IRequest<Guid>
{
    public required string Title { get; init; }
    public required Stream AudioFile { get; init; }
    public required Stream CoverImageFile { get; init; }
    public required Guid[] Artists { get; init; }
    public required Guid[] Tags { get; init; }
    public string? Lyrics { get; init; }
}

public class PublishSongCommandHandler(IFileStorage fileStorage, IApplicationDbContext dbContext)
    : IRequestHandler<PublishSongCommand, Guid>
{
    public async Task<Guid> Handle(PublishSongCommand command, CancellationToken cancellationToken)
    {
        Guid songId = Guid.NewGuid();

        string audioFileUrl = await fileStorage.Upload(command.AudioFile, cancellationToken);
        string coverImageUrl = await fileStorage.Upload(command.CoverImageFile, cancellationToken);

        AudioFile audioFile = new()
        {
            Url = audioFileUrl,
            SongId = songId,
            Quality = AudioQuality.HighQuality
        };

        List<AudioFile> audioFiles = [audioFile];

        List<SongArtist> songArtists = command.Artists
            .Select(artistId => new SongArtist { ArtistId = artistId, SongId = songId })
            .ToList();

        List<SongTag> songTags = command.Tags
            .Select(tagId => new SongTag { TagId = tagId, SongId = songId })
            .ToList();

        Song song = new()
        {
            Id = songId,
            Title = command.Title,
            Lyrics = command.Lyrics,
            CoverImageUrl = coverImageUrl,
            Audios = audioFiles,
            SongArtists = songArtists,
            SongTags = songTags
        };

        dbContext.Songs.Add(song);
        await dbContext.SaveChangesAsync(cancellationToken);

        return song.Id;
    }
}