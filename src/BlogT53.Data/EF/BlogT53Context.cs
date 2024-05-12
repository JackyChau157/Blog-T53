using BlogT53.Core.Domain.Content;
using BlogT53.Core.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BlogT53.Data.EF
{
    public class BlogT53Context : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public BlogT53Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<PostActivityLog> PostActivityLogs { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostInSeries> PostInSeries { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        //public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        //{
        //    var entries = ChangeTracker
        //        .Entries()
        //        .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        //    foreach (var entityEntry in entries)
        //    {
        //        var dateCreatedProp = entityEntry.Entity.GetType().GetProperty("DateCreated");
        //        if (entityEntry.State == EntityState.Added
        //            && dateCreatedProp != null)
        //        {
        //            dateCreatedProp.SetValue(entityEntry.Entity, DateTime.Now);
        //        }
        //        var modifiedDateProp = entityEntry.Entity.GetType().GetProperty("ModifiedDate");
        //        if (entityEntry.State == EntityState.Modified
        //            && modifiedDateProp != null)
        //        {
        //            modifiedDateProp.SetValue(entityEntry.Entity, DateTime.Now);
        //        }
        //    }
        //    return base.SaveChangesAsync(cancellationToken);
        //}
    }
}