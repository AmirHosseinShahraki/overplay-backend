using Api.Infrastructure;
using Application.Artists;
using Application.Artists.Queries.GetArtistsWithPagination;
using Application.Common.Models;
using MapsterMapper;
using MediatR;

namespace Api.Endpoints.Artists.GetArtists;

public class GetArtistsEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/artists",
            async (ISender sender, IMapper mapper, [AsParameters] GetArtistsRequest request) =>
            {
                GetArtistsWithPaginationQuery query = mapper.Map<GetArtistsWithPaginationQuery>(request);

                PaginatedList<ArtistBriefDto> response = await sender.Send(query);

                return Results.Ok(response);
            });
    }
}