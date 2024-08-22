using Api.Infrastructure;
using Application.Common.Models;
using Application.Songs;
using Application.Songs.Queries.GetSongsWithPagination;
using MapsterMapper;
using MediatR;

namespace Api.Endpoints.Songs.GetSongs;

public class GetSongsEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/songs",
            async (ISender sender, IMapper mapper, [AsParameters] GetSongsRequest request) =>
            {
                GetSongsWithPaginationQuery query = mapper.Map<GetSongsWithPaginationQuery>(request);

                PaginatedList<SongBriefDto> response = await sender.Send(query);

                return Results.Ok(response);
            });
    }
}