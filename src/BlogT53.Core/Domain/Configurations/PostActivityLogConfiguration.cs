using BlogT53.Core.Domain.Content;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogT53.Core.Domain.Configurations
{
    public class PostActivityLogConfiguration : IEntityTypeConfiguration<PostActivityLog>
    {
        public void Configure(EntityTypeBuilder<PostActivityLog> builder)
        {
        }
    }
}