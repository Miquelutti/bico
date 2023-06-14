using Fatec.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fatec.Domain.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task AddAsync(TEntity obj);
        void Add(TEntity obj);
        void Update(TEntity obj);
        Task<TEntity> FindById(long id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        void AddRange(IEnumerable<TEntity> entities);
        void Delete(TEntity obj);
    }
}
