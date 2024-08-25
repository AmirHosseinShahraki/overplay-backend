using Domain.ValueObjects;

namespace Application.AudioFiles;

public record AudioFileBriefDto
{
    public required string Url { get; init; }
    public required AudioQuality Quality { get; init; }
}