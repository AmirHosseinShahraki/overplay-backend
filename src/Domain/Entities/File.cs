using Domain.Common;

namespace Domain.Entities;

public abstract class File : BaseEntity<Guid>
{
    public Guid FileKey { get; set; }
}