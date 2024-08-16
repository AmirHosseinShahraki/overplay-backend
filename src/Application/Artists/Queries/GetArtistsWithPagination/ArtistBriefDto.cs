namespace Application.Artists.Queries.GetArtistsWithPagination;

public record ArtistBriefDto
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required DateTimeOffset CreatedAt { get; init; }
    public required DateTimeOffset UpdatedAt { get; init; }
}