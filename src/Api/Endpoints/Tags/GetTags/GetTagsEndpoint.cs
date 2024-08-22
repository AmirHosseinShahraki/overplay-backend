using Api.Infrastructure;
using Application.Common.Models;
using Application.Tags;
using Application.Tags.Queries.GetTagsWithPaginationQuery;
using MapsterMapper;
using MediatR;

namespace Api.Endpoints.Tags.GetTags;

public class GetTagsEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/tags/", async (ISender sender, IMapper mapper, [AsParameters] GetTagsRequest request) =>
        {
            GetTagsWithPaginationQuery query = mapper.Map<GetTagsWithPaginationQuery>(request);

            PaginatedList<TagBriefDto> tags = await sender.Send(query);

            return Results.Ok(tags);
        });
    }
}