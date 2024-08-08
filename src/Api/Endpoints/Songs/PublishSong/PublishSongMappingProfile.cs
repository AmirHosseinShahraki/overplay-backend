using Application.Songs.Commands.CreateSong;
using Mapster;

namespace Api.Endpoints.Songs.PublishSong;

public class PublishSongMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<PublishSongRequest, PublishSongCommand>();

        config.ForType<Guid, PublishSongResponse>()
            .Map(x => x.SongId, src => src);
    }
}