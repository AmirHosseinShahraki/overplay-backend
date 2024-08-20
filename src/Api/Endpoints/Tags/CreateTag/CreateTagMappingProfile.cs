using Application.Tags.Commands.CreateTag;
using Mapster;

namespace Api.Endpoints.Tags.CreateTag;

public class CreateTagMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<CreateTagRequest, CreateTagCommand>()
            .Map(x => x.Title, src => src.Title);

        config.ForType<Guid, CreateTagResponse>()
            .Map(x => x.TagId, src => src);
    }
}