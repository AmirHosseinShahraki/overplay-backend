using Domain.Common;

namespace Domain.Entities;

public class Song : BaseAuditableEntity<Guid>
{
    public string Title { get; set; } = null!;
    public string? Lyrics { get; set; }
    public CoverImageFile CoverImage { get; set; } = null!;
    public virtual ICollection<Artist> Artists { get; set; } = [];
    public virtual ICollection<SongArtist> SongArtists { get; set; } = [];
    public virtual ICollection<AudioFile> Audios { get; set; } = [];
    public virtual ICollection<Tag> Tags { get; set; } = [];
    public virtual ICollection<SongTag> SongTags { get; set; } = [];
}