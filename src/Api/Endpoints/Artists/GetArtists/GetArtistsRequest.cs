namespace Api.Endpoints.Artists.GetArtists;

public record GetArtistsRequest
{
    private int _size;
    private int _page;

    public int? Size
    {
        get => _size != 0 ? _size : null;
        set => _size = value ?? 10;
    }

    public int? Page
    {
        get => _page != 0 ? _page : 1;
        set => _page = value ?? 1;
    }
}