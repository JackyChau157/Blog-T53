using BlogT53.Core.SeedWorks;
using BlogT53.Data.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlogT53.Data.SeedWorks
{
    public class RepositoryBase<T, Key> : IRepositoty<T, Key> where T : class
    {
        private readonly DbSet<T> _dbSet;

        public RepositoryBase(BlogT53Context context)
        {
            _dbSet = context.Set<T>();
        }

        public async void AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Key id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}