using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
        builder.HasKey(a => a.Id);
        builder.HasIndex(a => a.Name);

        builder
            .HasMany(a => a.Songs)
            .WithMany(s => s.Artists)
            .UsingEntity<SongArtist>(
                j => j
                    .HasOne(sa => sa.Song)
                    .WithMany(s => s.SongArtists)
                    .HasForeignKey(sa => sa.SongId),
                j => j
                    .HasOne(sa => sa.Artist)
                    .WithMany(a => a.SongArtists)
                    .HasForeignKey(sa => sa.ArtistId),
                j =>
                {
                    j.HasKey(sa => new { sa.SongId, sa.ArtistId });
                });
    }
}