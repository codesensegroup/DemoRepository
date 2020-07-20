using InterfaceRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFRepository
{
    public abstract class EFRepository<TEntity> : IRepository<TEntity>
          where TEntity : class, new()
    {
        protected DbContext Context { get; private set; }

        public EFRepository(DbContext dbContext)
        {
            Context = dbContext;
        }

        public void Add(TEntity entity) => Context.Add(entity);

        public void AddRange(params TEntity[] entities) => Context.AddRange(entities);

        public IQueryable<TEntity> ReadRange() => Context.Set<TEntity>().AsQueryable();

        public void Remove(TEntity entity) => Context.Remove(entity);

        public void RemoveRange(params TEntity[] entities) => Context.RemoveRange(entities);

        public void Update(TEntity entity) => Context.Update(entity);

        public void UpdateRange(params TEntity[] entities) => Context.UpdateRange(entities);
    }
}
