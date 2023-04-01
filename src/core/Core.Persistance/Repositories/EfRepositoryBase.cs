using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories;

public class EfRepositoryBase<TEntity, TContext> : IRepository<TEntity>
where TEntity : Entity
where TContext : DbContext
{
    protected TContext Context { get; }

    public EfRepositoryBase(TContext context)
    {
        Context = context;
    }
    public IQueryable<TEntity> Query()
    {
        return Context.Set<TEntity>();
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, bool tracking = true)
    {
        return await Query().FirstOrDefaultAsync(predicate);
    }

    public IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate = null, bool tracking = true)
    {
        IQueryable<TEntity> queryable = Query().AsQueryable();

        if (predicate != null)
            queryable = Query().Where(predicate);
        
        if (!tracking)
            queryable = queryable.AsNoTracking();

        return queryable;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Added;
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Deleted;
        await Context.SaveChangesAsync();
        return entity;
    }
}
