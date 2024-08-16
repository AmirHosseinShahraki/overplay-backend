using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using Mapster;
using MediatR;

namespace Application.Artists.Queries.GetArtistsWithPagination;

public record GetArtistsWithPaginationQuery : IRequest<PaginatedList<ArtistBriefDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetArtistsWithPaginationQueryHandler(IApplicationDbContext dbContext)
    : IRequestHandler<GetArtistsWithPaginationQuery, PaginatedList<ArtistBriefDto>>
{
    public Task<PaginatedList<ArtistBriefDto>> Handle(GetArtistsWithPaginationQuery query,
        CancellationToken cancellationToken)
    {
        return dbContext.Artists
            .OrderByDescending(a => a.CreatedAt)
            .ProjectToType<ArtistBriefDto>()
            .PaginatedListAsync(query.PageNumber, query.PageSize);
    }
}