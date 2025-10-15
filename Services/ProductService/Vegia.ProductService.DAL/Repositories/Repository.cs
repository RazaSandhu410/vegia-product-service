using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Vegia.ProductService.Core.Interfaces;
using Vegia.ProductService.DAL.Contexts;

namespace Vegia.ProductService.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ProductDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(ProductDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            // Convert int to long since entities use long primary keys
            return await _dbSet.FindAsync((long)id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
            => await _dbSet.Where(predicate).ToListAsync();

        public virtual async Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
            => await _dbSet.SingleOrDefaultAsync(predicate);

        public virtual async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public virtual async Task AddRangeAsync(IEnumerable<T> entities) => await _dbSet.AddRangeAsync(entities);

        public virtual void Update(T entity) => _dbSet.Update(entity);

        public virtual void Remove(T entity) => _dbSet.Remove(entity);

        public virtual void RemoveRange(IEnumerable<T> entities) => _dbSet.RemoveRange(entities);

        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
            => await _dbSet.AnyAsync(predicate);

        public virtual async Task<int> CountAsync() => await _dbSet.CountAsync();

        public virtual async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
            => await _dbSet.CountAsync(predicate);
    }
}
