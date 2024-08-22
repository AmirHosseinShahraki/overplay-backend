namespace Api.Endpoints.Songs.GetSongs;

public record GetSongsRequest
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
        get => _page != 0 ? _page : null;
        set => _page = value ?? 1;
    }
};