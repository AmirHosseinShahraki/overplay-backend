using Domain.Entities;
using Infrastructure.Data.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class AudioFileConfiguration : IEntityTypeConfiguration<AudioFile>
{
    public void Configure(EntityTypeBuilder<AudioFile> builder)
    {
        builder.HasKey(af => af.Id);

        builder.Property(af => af.Quality)
            .HasConversion(new AudioQualityConverter());

        builder.HasOne(af => af.Song)
            .WithMany(s => s.Audios)
            .HasForeignKey(af => af.SongId);
    }
}