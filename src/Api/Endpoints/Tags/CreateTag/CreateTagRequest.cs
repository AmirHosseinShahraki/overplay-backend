namespace Api.Endpoints.Tags.CreateTag;

public record CreateTagRequest
{
    public required string Title { get; init; }
}