using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public async Task Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            using (TContext context = new TContext())
            {
                var deleteEntity = await context.Set<TEntity>().FindAsync(id);
                context.Set<TEntity>().Remove(deleteEntity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
            }
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public async Task Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TEntity>> Include(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            using (TContext context = new TContext())
            {
                var query = context.Set<TEntity>().AsQueryable();

                if(filter != null)
                {
                    query = query.Where(filter);
                }
                foreach (var include in includes)
                {
                    if (include.Body is MemberExpression memberExpression && memberExpression.Type.Name == "ICollection`1")
                    {
                        query = query.Include(include);
                        string propertyName = memberExpression.Member.Name;
                        //TODO: string yerine property bilgisinden include islemini yap.
                        PropertyInfo property = memberExpression.Member as PropertyInfo;
                        if(property.PropertyType.GetGenericArguments()[0].GetProperty(propertyName.Remove(propertyName.Length - 1)) != null)
                            query = query.Include($"{propertyName}.{propertyName.Remove(propertyName.Length - 1)}");

                        //string? thenInclude = thenIncludeSplit.LastOrDefault();
                        //if (propertyName.GetType().GetGenericArguments()[0].GetProperty(propertyName.Remove(propertyName.Length - 1)) != null)
                    }
                    else
                    {
                        query = query.Include(include);
                    }
                }

                return await query.ToListAsync();
            }
        }


        public async Task<IEnumerable<TEntity>> Include1(params Expression<Func<TEntity, object>>[] includes) 
        {
            using (TContext context = new TContext())
            {
                var query = context.Set<TEntity>().AsQueryable();

                foreach (var include in includes)
                {
                    if (include.Body is MemberExpression memberExpression && memberExpression.Type.Name == "ICollection`1")
                    {
                        query = query.Include(include);
                        string propertyName = memberExpression.Member.Name;
                        query = query.Include($"{propertyName}.{nameof(TEntity)}");
                    }
                    else
                    {
                        query = query.Include(include);
                    }
                }

                return await query.ToListAsync();
            }
        }


    }
}