﻿using Dapper.Contrib.Extensions;
using InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DapperRepository
{
    /// <summary>
    /// 泛型Repository版本，(Table版本)
    /// </summary>
    public class DapperGenericRepository<TEntity> : DapperRepositoryTemplate, IDapperGenericRepository<TEntity>
        where TEntity : class, new()
    {
        static DapperGenericRepository()
        {
            if (SqlMapperExtensions.TableNameMapper == null) SqlMapperExtensions.TableNameMapper += (t) => t.Name;
        }

        /// <summary>
        /// 傳統
        /// </summary>
        public DapperGenericRepository(IDbConnection connection) : base(connection)
        {
        }

        /// <summary>
        /// 交易Unit of work
        /// </summary>
        public DapperGenericRepository(Func<IDbTransaction> transactionFactory, int? commandTimeout = null) : base(transactionFactory, commandTimeout)
        {
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
