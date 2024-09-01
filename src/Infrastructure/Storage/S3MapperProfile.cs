using Amazon.S3;
using Application.Common.Interfaces.FileStorage;
using Mapster;

namespace Infrastructure.Storage;

public class S3MapperProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        Dictionary<FileAccessControl, S3CannedACL> mappingDictionary = new()
        {
            { FileAccessControl.Private, S3CannedACL.Private },
            { FileAccessControl.PublicRead, S3CannedACL.PublicRead },
        };

        config.ForType<FileAccessControl, S3CannedACL>()
            .Map(dest => dest, src => mappingDictionary[src]);
    }
}