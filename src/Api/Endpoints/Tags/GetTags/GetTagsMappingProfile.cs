using Application.Tags.Queries.GetTagsWithPaginationQuery;
using Mapster;

namespace Api.Endpoints.Tags.GetTags;

public class GetTagsMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<GetTagsRequest, GetTagsWithPaginationQuery>()
            .Map(x => x.PageNumber, src => src.Page)
            .Map(x => x.PageSize, src => src.Size);
    }
}