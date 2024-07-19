using Domain.Common;

namespace Domain.Entities;

public class Tag : BaseEntity<Guid>
{
    public string Title { get; set; } = null!;
    public virtual ICollection<SongTag> SongTags { get; set; } = [];
}