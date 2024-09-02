namespace Application.Common.Interfaces.FileStorage;

public interface IFileStorage
{
    public Task<Guid> Upload(Stream stream, FileAccessControl fileAccessControl, CancellationToken cancellationToken);
}