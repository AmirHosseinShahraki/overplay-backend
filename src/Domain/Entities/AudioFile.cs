using Domain.ValueObjects;

namespace Domain.Entities;

public class AudioFile : File
{
    public AudioQuality Quality { get; set; } = null!;
    public Guid SongId { get; set; }
    public virtual Song Song { get; set; } = null!;
}