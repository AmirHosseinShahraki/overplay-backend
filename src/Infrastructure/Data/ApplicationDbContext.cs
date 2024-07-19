using System.Reflection;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
    : DbContext(dbContextOptions), IApplicationDbContext
{
    public DbSet<Artist> Artists => Set<Artist>();
    public DbSet<Song> Songs => Set<Song>();
    public DbSet<AudioFile> AudioFiles => Set<AudioFile>();
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<SongTag> SongTags => Set<SongTag>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}