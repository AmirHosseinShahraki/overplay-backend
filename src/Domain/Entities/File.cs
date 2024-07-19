using Domain.Common;

namespace Domain.Entities;

public abstract class File : BaseAuditableEntity<Guid>
{
    public string Url { get; set; } = null!;
}