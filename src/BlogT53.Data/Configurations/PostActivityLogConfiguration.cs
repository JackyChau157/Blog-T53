using BlogT53.Core.Domain.Content;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogT53.Data.Configurations
{
    public class PostActivityLogConfiguration : IEntityTypeConfiguration<PostActivityLog>
    {
        public void Configure(EntityTypeBuilder<PostActivityLog> builder)
        {
            builder.ToTable("PostActivityLogs").HasKey(x => x.Id);
            builder.Property(x => x.Note).HasMaxLength(500);
        }
    }
}