using BlogT53.Core.Domain.Content;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogT53.Data.Configurations
{
    public class PostInSeriesConfiguration : IEntityTypeConfiguration<PostInSeries>
    {
        public void Configure(EntityTypeBuilder<PostInSeries> builder)
        {
            builder.ToTable("PostInSeries").HasKey(x => x.PostId);
        }
    }
}