using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.Songs.PublishSong;

public record PublishSongRequest
{
    [FromForm]
    public required string Title { get; init; }

    [FromForm]
    public string? Lyrics { get; init; }

    public required IFormFile CoverImageFile { get; init; }

    public required IFormFile AudioFile { get; init; }

    [FromForm]
    public required Guid[] Artists { get; init; } = [];

    [FromForm]
    public Guid[] Tags { get; init; } = [];
}