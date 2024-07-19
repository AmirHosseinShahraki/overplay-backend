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

        builder.HasMany(s => s.SongTags)
            .WithOne(st => st.Song)
            .HasForeignKey(st => st.SongId);

        builder.HasMany(s => s.Artists)
            .WithMany(a => a.Songs);
    }
}