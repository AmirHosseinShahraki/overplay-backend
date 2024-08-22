using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using Mapster;
using MediatR;

namespace Application.Songs.Queries.GetSongsWithPagination;

public record GetSongsWithPaginationQuery : IRequest<PaginatedList<SongBriefDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
};

public class GetSongsWithPaginationQueryHandler(IApplicationDbContext dbContext)
    : IRequestHandler<GetSongsWithPaginationQuery, PaginatedList<SongBriefDto>>
{
    public Task<PaginatedList<SongBriefDto>> Handle(GetSongsWithPaginationQuery query,
        CancellationToken cancellationToken)
    {
        return dbContext.Songs
            .OrderByDescending(a => a.CreatedAt)
            .ProjectToType<SongBriefDto>()
            .PaginatedListAsync(query.PageNumber, query.PageSize);
    }
}