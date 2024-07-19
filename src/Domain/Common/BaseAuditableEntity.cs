namespace Domain.Common;

public abstract class BaseAuditableEntity<T> : BaseEntity<T>
{
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset LastModifiedAt { get; set; }
}