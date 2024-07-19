using Domain.Common;

namespace Domain.Entities;

public class Song : BaseAuditableEntity<Guid>
{
    public string Title { get; set; } = null!;
    public string? Lyrics { get; set; }
    public CoverImageFile CoverImage { get; set; } = null!;
    public List<AudioFile> Audios { get; set; } = [];
    public List<Tag> Tags { get; set; } = [];
}