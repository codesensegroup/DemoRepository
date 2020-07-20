using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DapperRepository
{
    /// <summary>
    /// Domain Drvier Design Repository版本
    /// </summary>
    public abstract class DapperRepository<TEntity> : IDapperRepository<TEntity>
        where TEntity : class, new()
    {
        protected IDbTransaction Transaction { get; }

        protected IDbConnection Connection => Transaction.Connection;

        protected int? CommandTimeout { get; private set; }

        static DapperRepository()
        {
            if (SqlMapperExtensions.TableNameMapper == null) SqlMapperExtensions.TableNameMapper += (t) => t.Name;
        }

        public DapperRepository(IDbTransaction transaction, int? commandTimeout = null)
        {
            Transaction = transaction;
            CommandTimeout = commandTimeout;
        }

        public virtual void Add(TEntity entity) => Connection.Insert(entity, Transaction, CommandTimeout);

        public virtual void AddRange(params TEntity[] entities) => Connection.Insert(entities, Transaction, CommandTimeout);


        public void Remove(TEntity entity) => Connection.Delete(entity, Transaction, CommandTimeout);

        public void RemoveRange(params TEntity[] entities) => Connection.Delete(entities, Transaction, CommandTimeout);

        public IQueryable<TEntity> ReadRange() => Connection.GetAll<TEntity>(Transaction, CommandTimeout).AsQueryable();

        public virtual void Update(TEntity entity) => Connection.Update(entity, Transaction, CommandTimeout);

        public virtual void UpdateRange(params TEntity[] entities) => Connection.Update(entities, Transaction, CommandTimeout);
    }
}
