﻿using Core.Entities;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null);
        Task<T> Get(Expression<Func<T, bool>> filter);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
        Task<IEnumerable<T>> Include(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);
    }
}