using Application.Artists;
using Application.Tags;

namespace Application.Songs;

public record SongBriefDto
{
    public required Guid Id { get; init; }
    public required string Title { get; init; }
    public required string CoverImageUrl { get; init; }
    public required ArtistBriefDto[] Artists { get; init; }
    public required TagBriefDto[] Tags { get; init; }
    public required DateTimeOffset CreatedAt { get; set; }
    public required DateTimeOffset UpdatedAt { get; set; }
}