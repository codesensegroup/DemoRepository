using InterfaceRepository;
using System;

namespace DapperRepository
{
    /// <summary>
    /// Dapper Unit Of Work
    /// </summary>
    public interface IDapperUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// 取得介面型(DDD) + 混合型(DDD + Table)
        /// </summary>
        TRepository GetRepository<TRepository>() where TRepository : class;

        /// <summary>
        /// 取得泛型(Table版本)
        /// </summary>
        IDapperGenericRepository<TEntity> GetGenericRepository<TEntity>() where TEntity : class, new();
    }
}
