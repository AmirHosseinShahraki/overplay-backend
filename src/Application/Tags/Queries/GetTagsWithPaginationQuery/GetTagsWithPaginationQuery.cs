using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using Mapster;
using MediatR;

namespace Application.Tags.Queries.GetTagsWithPaginationQuery;

public record GetTagsWithPaginationQuery : IRequest<PaginatedList<TagBriefDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetTagsWithPaginationQueryHandler(IApplicationDbContext dbContext)
    : IRequestHandler<GetTagsWithPaginationQuery, PaginatedList<TagBriefDto>>
{
    public Task<PaginatedList<TagBriefDto>> Handle(GetTagsWithPaginationQuery query,
        CancellationToken cancellationToken)
    {
        return dbContext.Tags
            .ProjectToType<TagBriefDto>()
            .PaginatedListAsync(query.PageNumber, query.PageSize);
    }
}