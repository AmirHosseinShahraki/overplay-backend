using Domain.ValueObjects;

namespace Application.AudioFiles;

public record AudioFileBriefDto
{
    public required Guid FileKey { get; init; }
    public required AudioQuality Quality { get; init; }
}