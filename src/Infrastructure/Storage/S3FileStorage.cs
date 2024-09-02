using Amazon.S3;
using Amazon.S3.Model;
using MapsterMapper;
using Microsoft.Extensions.Options;
using Application.Common.Exceptions;
using Application.Common.Interfaces.FileStorage;

namespace Infrastructure.Storage;

public class S3FileStorage(
    IOptions<S3Configuration> configuration,
    AmazonS3Client client,
    IMapper mapper)
    : IFileStorage
{
    private readonly S3Configuration _configuration = configuration.Value;

    public async Task<Guid> Upload(
        Stream stream,
        FileAccessControl fileAccessControl,
        CancellationToken cancellationToken)
    {
        Guid key = Guid.NewGuid();

        S3CannedACL acl = mapper.Map<S3CannedACL>(fileAccessControl);

        PutObjectRequest request = new()
        {
            BucketName = _configuration.DefaultBucket,
            Key = key.ToString(),
            InputStream = stream,
            CannedACL = acl
        };

        PutObjectResponse response = await client.PutObjectAsync(request, cancellationToken);

        if (response is null)
        {
            throw new UploadFileFailedException();
        }

        return key;
    }
}