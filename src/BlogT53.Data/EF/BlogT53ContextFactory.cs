using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BlogT53.Data.EF
{
    public class BlogT53ContextFactory : IDesignTimeDbContextFactory<BlogT53Context>
    {
        public BlogT53Context CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();
            var builder = new DbContextOptionsBuilder<BlogT53Context>();
            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            return new BlogT53Context(builder.Options);
        }
    }
}