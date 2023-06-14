using Fatec.Domain.Entities;
using Fatec.Domain.Repositories.Interfaces;
using Fatec.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fatec.Infrastructure.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(BicoContext context)
        {
            DbSet = context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity obj)
        {
            await DbSet.AddAsync(obj);
        }

        public void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            DbSet.AddRange(entities);
        }

        public virtual async Task<TEntity> FindById(long id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }
        public void Delete(TEntity obj)
        {
            DbSet.Remove(obj);
        }

        public virtual IQueryable<TEntity> NoTracking() => DbSet.AsNoTracking();
    }
}
