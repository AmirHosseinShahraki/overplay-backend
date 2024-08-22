namespace Infrastructure.Storage;

public record S3Configuration
{
    public required string Url { get; init; }
    public required string AccessKey { get; init; }
    public required string SecretKey { get; init; }
    public required string DefaultBucket { get; init; }
}