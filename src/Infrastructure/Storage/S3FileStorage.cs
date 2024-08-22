using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Application.Common.Interfaces;
using Microsoft.Extensions.Options;

namespace Infrastructure.Storage;

public class S3FileStorage : IFileStorage
{
    private readonly AmazonS3Client _client;
    private readonly S3Configuration _configuration;

    public S3FileStorage(IOptions<S3Configuration> configuration)
    {
        _configuration = configuration.Value;

        BasicAWSCredentials credentials = new(
            _configuration.AccessKey,
            _configuration.SecretKey
        );

        AmazonS3Config config = new()
        {
            ServiceURL = _configuration.Url
        };

        _client = new AmazonS3Client(credentials, config);
    }

    public async Task<string> Upload(Stream stream, CancellationToken cancellationToken)
    {
        string key = Guid.NewGuid().ToString();

        PutObjectRequest request = new()
        {
            BucketName = _configuration.DefaultBucket,
            Key = key,
            InputStream = stream
        };

        PutObjectResponse response = await _client.PutObjectAsync(request, cancellationToken);

        return $"{_configuration.Url}/{key}";
    }
}