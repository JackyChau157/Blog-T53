using BlogT53.Core.Domain.Content;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogT53.Data.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts").HasKey(x => x.Id);
            builder.HasIndex(x => x.Slug).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();
            builder.Property(x => x.Slug).HasColumnType("varchar(250)").IsRequired();
            builder.Property(x => x.SeoDescription).HasMaxLength(160);
            builder.Property(x => x.Thumbnail).HasMaxLength(500);
            builder.Property(x => x.AuthorUserId).HasMaxLength(500);
            builder.Property(x => x.CategoryId).IsRequired();
        }
    }
}