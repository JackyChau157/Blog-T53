using BlogT53.Core.Domain.Content;
using BlogT53.Core.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogT53.Data.Configurations
{
    public class IdentityUserTokenClaimConfiguration : IEntityTypeConfiguration<IdentityUserToken<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserToken<Guid>> builder)
        {
            builder.ToTable("AppUserTokens").HasKey(x => new { x.UserId });
        }
    }
}