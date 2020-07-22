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
        private Func<IDbTransaction> TransactionFactory { get; }

        protected IDbTransaction Transaction => TransactionFactory.Invoke();

        protected IDbConnection Connection => Transaction.Connection;

        protected int? CommandTimeout { get; }

        /// <summary>
        /// 創建IDbTransaction工廠，每次引用的時候，都會去重新取得IDbTransaction的參考位址，否則Commit之後，Connection會被釋放掉，造成null reference
        /// </summary>
        public DapperRepositoryTemplate(Func<IDbTransaction> transactionFactory, int? commandTimeout = null)
        {
            TransactionFactory = transactionFactory;
            CommandTimeout = commandTimeout;             
        }
    }     
}
