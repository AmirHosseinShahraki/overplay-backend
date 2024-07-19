using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Artist> Artists { get; }
    DbSet<Song> Songs { get; }
    DbSet<AudioFile> AudioFiles { get; }
    DbSet<Tag> Tags { get; }
    DbSet<SongTag> SongTags { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}