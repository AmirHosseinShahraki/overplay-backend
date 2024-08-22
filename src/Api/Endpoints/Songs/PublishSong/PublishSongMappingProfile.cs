using Application.Songs.Commands.PublishSong;
using Mapster;

namespace Api.Endpoints.Songs.PublishSong;

public class PublishSongMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<IFormFile, Stream>()
            .MapWith(src => src.OpenReadStream());

        config.ForType<PublishSongRequest, PublishSongCommand>()
            .Map(x => x.Title, src => src.Title)
            .Map(x => x.Artists, src => src.Artists)
            .Map(x => x.Tags, src => src.Tags)
            .Map(x => x.Lyrics, src => src.Lyrics)
            .Map(x => x.AudioFile, src => src.AudioFile)
            .Map(x => x.CoverImageFile, src => src.CoverImageFile);

        config.ForType<Guid, PublishSongResponse>()
            .Map(x => x.SongId, src => src);
    }
}