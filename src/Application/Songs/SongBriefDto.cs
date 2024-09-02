using System.Text.Json.Serialization;
using Application.Artists;
using Application.Tags;

namespace Application.Songs;

public record SongBriefDto
{
    [JsonPropertyOrder(1)]
    public required Guid Id { get; init; }

    [JsonPropertyOrder(2)]
    public required string Title { get; init; }

    [JsonPropertyOrder(3)]
    public required Guid CoverImageFileKey { get; init; }

    [JsonPropertyOrder(4)]
    public required ArtistBriefDto[] Artists { get; init; }

    [JsonPropertyOrder(5)]
    public required TagBriefDto[] Tags { get; init; }

    [JsonPropertyOrder(int.MaxValue)]
    public required DateTimeOffset CreatedAt { get; set; }

    [JsonPropertyOrder(int.MaxValue)]
    public required DateTimeOffset UpdatedAt { get; set; }
}