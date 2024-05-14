using BlogT53.Core.Domain.Content;
using BlogT53.Core.SeedWorks;

namespace BlogT53.Core.Repositories
{
    public interface IPostRepository : IRepository<Post, Guid>
    {
        Task<List<Post>> GetPopularPostsAsync(int count);
    }
}