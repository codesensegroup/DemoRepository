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
        private readonly IDbConnection _connection;

        private readonly Func<IDbTransaction> _transactionFactory;

        protected IDbTransaction Transaction => _transactionFactory?.Invoke();

        protected IDbConnection Connection => _connection ?? Transaction.Connection;

        protected int? CommandTimeout { get; }

        /// <summary>
        /// 創建IDbTransaction工廠，每次引用的時候，都會去重新取得IDbTransaction的參考位址，否則Commit之後，Connection會被釋放掉，造成null reference
        /// DB交易
        /// </summary>
        public DapperRepositoryTemplate(Func<IDbTransaction> transactionFactory, int? commandTimeout = null)
        {
            _transactionFactory = transactionFactory;
            CommandTimeout = commandTimeout;
        }

        /// <summary>
        /// 單獨對Table進行操作
        /// </summary>
        public DapperRepositoryTemplate(IDbConnection connection)
        {
            _connection = connection;
        }
    }
}
