using BlogT53.Core.Domain.Content;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogT53.Data.Configurations
{
    public class PostCategoryConfiguration : IEntityTypeConfiguration<PostCategory>
    {
        public void Configure(EntityTypeBuilder<PostCategory> builder)
        {
            builder.ToTable("PostCategories").HasKey(x => x.Id);
            builder.HasIndex(x => x.Slug).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(256);
            builder.Property(x => x.Slug).HasColumnType("varchar(250)");
            builder.Property(x => x.SeoDescription).HasMaxLength(160);
        }
    }
}