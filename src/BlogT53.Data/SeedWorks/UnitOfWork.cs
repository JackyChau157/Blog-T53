using BlogT53.Core.SeedWorks;
using BlogT53.Data.EF;

namespace BlogT53.Data.SeedWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogT53Context _context;

        public UnitOfWork(BlogT53Context context)
        {
            _context = context;
        }

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