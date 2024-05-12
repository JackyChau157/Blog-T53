using BlogT53.Core.Domain.Content;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogT53.Data.Configurations
{
    public class SeriesConfiguration : IEntityTypeConfiguration<Series>
    {
        public void Configure(EntityTypeBuilder<Series> builder)
        {
            builder.ToTable("Series").HasKey(x => x.Id);
            builder.HasIndex(x => x.Slug).IsUnique();
            builder.Property(x => x.Slug).HasColumnType("varchar(250)");
            builder.Property(x => x.Name).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.Thumbnail).HasMaxLength(250);
        }
    }
}