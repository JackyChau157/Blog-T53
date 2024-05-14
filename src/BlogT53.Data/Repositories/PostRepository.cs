using BlogT53.Core.Domain.Content;
using BlogT53.Core.Repositories;
using BlogT53.Data.EF;
using BlogT53.Data.SeedWorks;

namespace BlogT53.Data.Repositories
{
    public class PostRepository : RepositoryBase<Post, Guid>, IPostRepository
    {
        public PostRepository(BlogT53Context context) : base(context)
        {
        }

        public Task<List<Post>> GetPopularPostsAsync(int count)
        {
            throw new NotImplementedException();
        }
    }
}