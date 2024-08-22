using Application.Songs.Queries.GetSongsWithPagination;
using Mapster;

namespace Api.Endpoints.Songs.GetSongs;

public class GetSongsMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<GetSongsRequest, GetSongsWithPaginationQuery>()
            .Map(x => x.PageNumber, src => src.Page)
            .Map(x => x.PageSize, src => src.Size);
    }
}