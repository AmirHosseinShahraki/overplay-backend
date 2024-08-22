using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class SongConfiguration : IEntityTypeConfiguration<Song>
{
    public void Configure(EntityTypeBuilder<Song> builder)
    {
        builder.HasKey(s => s.Id);
        builder.HasIndex(s => s.Title);

        builder.Property(s => s.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(s => s.Lyrics)
            .HasMaxLength(-1);

        builder.Property(s => s.CreatedAt)
            .IsRequired();

        builder.Property(s => s.UpdatedAt)
            .IsRequired();

        builder.HasMany(s => s.Audios)
            .WithOne(a => a.Song)
            .HasForeignKey(a => a.SongId);

        builder
            .HasMany(s => s.Tags)
            .WithMany(t => t.Songs)
            .UsingEntity<SongTag>(
                j => j
                    .HasOne(st => st.Tag)
                    .WithMany(t => t.SongTags)
                    .HasForeignKey(st => st.TagId),
                j => j
                    .HasOne(st => st.Song)
                    .WithMany(s => s.SongTags)
                    .HasForeignKey(st => st.SongId),
                j =>
                {
                    j.HasKey(st => new { st.SongId, st.TagId });
                });

        builder
            .HasMany(s => s.Artists)
            .WithMany(a => a.Songs)
            .UsingEntity<SongArtist>(
                j => j
                    .HasOne(sa => sa.Artist)
                    .WithMany(a => a.SongArtists)
                    .HasForeignKey(sa => sa.ArtistId),
                j => j
                    .HasOne(sa => sa.Song)
                    .WithMany(s => s.SongArtists)
                    .HasForeignKey(sa => sa.SongId),
                j =>
                {
                    j.HasKey(sa => new { sa.SongId, sa.ArtistId });
                });
    }
}