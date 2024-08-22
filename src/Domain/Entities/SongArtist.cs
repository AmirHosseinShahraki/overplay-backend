namespace Domain.Entities;

public class SongArtist
{
    public Guid SongId { get; set; }
    public virtual Song Song { get; set; } = null!;
    public Guid ArtistId { get; set; }
    public virtual Artist Artist { get; set; } = null!;
}