using BlogT53.Core.Domain.Content;
using BlogT53.Core.Models;
using BlogT53.Core.Models.Content;
using BlogT53.Core.SeedWorks;

namespace BlogT53.Core.Repositories
{
    public interface IPostRepository : IRepository<Post, Guid>
    {
        Task<List<Post>> GetPopularPostsAsync(int count);

        Task<PagedResult<PostInListDto>> GetPostsPagingAsync(string keyword, Guid? categoryId, int pageIndex = 1, int pageSize = 10);
    }
}