﻿using System.Linq.Expressions;

namespace BlogT53.Core.SeedWorks
{
    public interface IRepositoty<T, Key> where T : class
    {
        Task<T> GetByIdAsync(Key id);

        Task<IEnumerable<T>> GetAllAsync();

        IEnumerable<T> Find(Expression<Func<T, bool>> expression);

        void AddAsync(T entity);

        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);
    }
}