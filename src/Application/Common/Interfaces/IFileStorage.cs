namespace Application.Common.Interfaces;

public interface IFileStorage
{
    public Task<string> Upload(Stream stream, CancellationToken cancellationToken);
}