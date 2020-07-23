using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DapperRepository.Repository
{
    public class SimpleDapperGenericRepository<TEntity> : IDapperGenericRepository<TEntity>
        where TEntity : class, new()
    {
        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> ReadRange()
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }
    }
}
