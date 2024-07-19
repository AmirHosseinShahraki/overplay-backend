using Domain.Common;

namespace Domain.Entities;

public class Song : BaseAuditableEntity<Guid>
{
    public string Title { get; set; } = null!;
    public string? Lyrics { get; set; }
    public CoverImageFile CoverImage { get; set; } = null!;
    public virtual ICollection<Artist> Artists { get; set; } = null!;
    public virtual ICollection<AudioFile> Audios { get; set; } = [];
    public virtual ICollection<SongTag> SongTags { get; set; } = [];
}