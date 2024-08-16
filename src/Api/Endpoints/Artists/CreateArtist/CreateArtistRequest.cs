namespace Api.Endpoints.Artists.CreateArtist;

public record CreateArtistRequest
{
    public required string Name { get; init; }
}