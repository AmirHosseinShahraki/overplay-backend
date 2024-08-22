namespace Application.Tags;

public record TagBriefDto
{
    public required Guid Id { get; init; }
    public required string Title { get; init; }
}