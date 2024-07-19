using Domain.Common;

namespace Domain.Entities;

public abstract class File : BaseEntity<Guid>
{
    public string Url { get; set; } = null!;
}