namespace Application.Common.Interfaces.FileStorage;

public interface IFileStorage
{
    public Task<string> Upload(Stream stream, FileAccessControl fileAccessControl, CancellationToken cancellationToken);
}