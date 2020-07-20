using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DapperRepository
{
     
    /// <summary>
    /// Table Repository版本 (含有自訂Key)
    /// </summary>
    public abstract class DapperTableRepository<TKey, TEntity> : DapperRepository<TEntity>, IDapperTableRepository<TKey, TEntity>
        where TEntity : class, new()
    {
        public DapperTableRepository(IDbTransaction transaction, int? commandTimeout = null) : base(transaction, commandTimeout)
        {
        }

        public void Delete(TKey key) => Connection.Delete(Read(key), Transaction, CommandTimeout);

        public TEntity Read(TKey key) => Connection.Get<TEntity>(key, Transaction, CommandTimeout);
    }
}
