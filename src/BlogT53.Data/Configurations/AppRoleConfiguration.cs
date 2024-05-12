using BlogT53.Core.Domain.Content;
using BlogT53.Core.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogT53.Data.Configurations
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.ToTable("AppRoles").HasKey(x => x.Id);
            builder.Property(x => x.DisplayName)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}