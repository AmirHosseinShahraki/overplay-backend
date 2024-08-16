namespace Api.Endpoints.Artists.CreateArtist;

public record CreateArtistResponse
{
    public required Guid ArtistId { get; init; }
}