using Amazon.Runtime;
using Amazon.S3;
using Application.Common.Interfaces.FileStorage;
using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Storage;

internal static class S3DependencyInjection
{
    public static IServiceCollection ConfigureS3(this IServiceCollection services, IConfiguration configuration)
    {
        IConfigurationSection s3ConfigSection = configuration.GetSection("S3Configuration");

        S3Configuration? s3Configuration = s3ConfigSection.Get<S3Configuration>();

        Guard.Against.Null(s3Configuration, message: "S3 configuration not found");

        services.Configure<S3Configuration>(s3ConfigSection);

        BasicAWSCredentials credentials = new(
            s3Configuration.AccessKey,
            s3Configuration.SecretKey
        );
        AmazonS3Config config = new()
        {
            ServiceURL = s3Configuration.Url
        };
        AmazonS3Client client = new(credentials, config);

        services.AddSingleton(client);

        services.AddScoped<IFileStorage, S3FileStorage>();

        return services;
    }
}