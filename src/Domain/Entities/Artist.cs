using Domain.Common;

namespace Domain.Entities;

public class Artist : BaseAuditableEntity<Guid>
{
    public string Name { get; set; } = null!;
}