using Hahn.ApplicatonProcess.July2021.Domain.Base;
using Hahn.ApplicatonProcess.July2021.Domain.Entities;
using Hahn.ApplicatonProcess.July2021.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Data.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : BaseEntity
    {
        private readonly DbSet<T> _dbSet;

        public RepositoryBase(EFDBContext dbContext)
        {
            _dbSet = dbContext.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public Task<bool> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return Task.FromResult(true);
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefaultAsync(expression);
        }

        public Task<List<T>> ListAsync(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).ToListAsync();
        }

        public Task<List<T>> ListAllAsync()
        {
            return _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> GetAllAsync<TProperty>(Expression<Func<T, TProperty>> include)
        {
            IQueryable<T> query = _dbSet.Include(include);

            return await query.ToListAsync().ConfigureAwait(false);
        }

        public Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return Task.FromResult(entity);
        }

        public Task<T> FindAsync(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefaultAsync(expression);
        }
    }
}
