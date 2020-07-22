using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DapperRepository
{
    /// <summary>
    /// Dapper Repository抽象類別版本
    /// </summary>
    public abstract class DapperRepositoryTemplate
    {
        protected IDbTransaction Transaction { get; }

        protected IDbConnection Connection => Transaction.Connection;

        protected int? CommandTimeout { get; }

        public DapperRepositoryTemplate(IDbTransaction transaction, int? commandTimeout = null)
        {
            Transaction = transaction;
            CommandTimeout = commandTimeout;
        }
    }     
}
