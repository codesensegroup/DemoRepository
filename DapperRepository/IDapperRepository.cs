using InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperRepository
{
    public interface IDapperRepository<TEntity> : IRepository<TEntity>
     where TEntity : class, new()
    {
    }

    public interface IDapperTableRepository<TKey, TEntity> : IRepository<TEntity>
       where TEntity : class, new()
    {
        TEntity Read(TKey key);

        void Delete(TKey key);
    }
}
