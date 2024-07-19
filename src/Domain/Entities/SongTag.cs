namespace Domain.Entities;

public class SongTag
{
    public Guid SongId { get; set; }
    public virtual Song Song { get; set; } = null!;
    public Guid TagId { get; set; }
    public virtual Tag Tag { get; set; } = null!;
}