namespace Api.Endpoints.Tags.CreateTag;

public record CreateTagResponse
{
    public required Guid TagId { get; init; }
}