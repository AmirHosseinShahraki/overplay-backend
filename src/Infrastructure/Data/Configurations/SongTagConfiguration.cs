using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class SongTagConfiguration : IEntityTypeConfiguration<SongTag>
{
    public void Configure(EntityTypeBuilder<SongTag> builder)
    {
        builder.HasKey(s => new { s.SongId, s.TagId });
    }
}