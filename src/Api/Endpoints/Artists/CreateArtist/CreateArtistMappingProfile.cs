using Application.Artists.Commands.CreateArtist;
using Mapster;

namespace Api.Endpoints.Artists.CreateArtist;

public class CreateArtistMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<CreateArtistRequest, CreateArtistCommand>()
            .Map(x => x.Name, src => src.Name);

        config.ForType<Guid, CreateArtistResponse>()
            .Map(x => x.ArtistId, src => src);
    }
}