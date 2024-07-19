using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasKey(t => t.Id);
        builder.HasIndex(t => t.Title);

        builder.HasMany(t => t.SongTags)
            .WithOne(s => s.Tag)
            .HasForeignKey(st => st.TagId);
    }
}