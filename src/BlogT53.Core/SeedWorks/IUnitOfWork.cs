using BlogT53.Core.Repositories;

namespace BlogT53.Core.SeedWorks
{
    public interface IUnitOfWork
    {
        IPostRepository Posts { get; }

        Task<int> CompleteAsync();
    }
}