namespace Application.Artists;

public record ArtistBriefDto
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
}