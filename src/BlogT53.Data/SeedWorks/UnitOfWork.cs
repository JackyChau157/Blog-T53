using AutoMapper;
using BlogT53.Core.Repositories;
using BlogT53.Core.SeedWorks;
using BlogT53.Data.EF;
using BlogT53.Data.Repositories;

namespace BlogT53.Data.SeedWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogT53Context _context;

        public UnitOfWork(BlogT53Context context, IMapper mapper)
        {
            _context = context;
            Posts = new PostRepository(context, mapper);
        }

        public IPostRepository Posts { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}