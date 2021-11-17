﻿using Hahn.ApplicatonProcess.July2021.Domain.Base;
using Hahn.ApplicatonProcess.July2021.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Domain.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<bool> DeleteAsync(T entity);

        Task<T> GetAsync(Expression<Func<T, bool>> expression);

        Task<List<T>> ListAsync(Expression<Func<T, bool>> expression);

        Task<List<T>> ListAllAsync();

        Task<T> FindAsync(Expression<Func<T, bool>> expression);

        Task<IEnumerable<T>> GetAllAsync<TProperty>(Expression<Func<T, TProperty>> include);

        //EntityEntry<T> AddIfNotExists<T>(DbSet<T> dbSet, T entity, Expression<Func<T, bool>> predicate = null) where T : class, new();
    }
}
