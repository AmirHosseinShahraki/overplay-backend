using Application.Common.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Songs.Queries.GetSong;

public class GetSongQuery : IRequest<SongDto>
{
    public required Guid Id { get; init; }
}

public class GetSongQueryHandler(IApplicationDbContext dbContext) : IRequestHandler<GetSongQuery, SongDto>
{
    public Task<SongDto> Handle(GetSongQuery query, CancellationToken cancellationToken)
    {
        return dbContext.Songs
            .Where(s => s.Id == query.Id)
            .Include(s => s.Audios)
            .ProjectToType<SongDto>()
            .AsNoTracking()
            .FirstAsync(cancellationToken);
    }
}