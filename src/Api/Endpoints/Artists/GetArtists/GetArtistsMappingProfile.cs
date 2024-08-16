using Application.Artists.Queries.GetArtistsWithPagination;
using Mapster;

namespace Api.Endpoints.Artists.GetArtists;

public class GetArtistsMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<GetArtistsRequest, GetArtistsWithPaginationQuery>()
            .Map(x => x.PageNumber, src => src.Page)
            .Map(x => x.PageSize, src => src.Size);
    }
}