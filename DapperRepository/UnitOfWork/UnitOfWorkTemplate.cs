using InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DapperRepository
{
    /// <summary>
    /// UnitOfWork共用抽象類別
    /// </summary>
    public abstract class UnitOfWorkTemplate : IUnitOfWork
    {
        /// <summary>
        /// DB連線
        /// </summary>
        protected IDbConnection Connection { get; private set; }

        /// <summary>
        /// DB交易
        /// </summary>
        protected IDbTransaction Transaction { get; private set; }

        /// <summary>
        /// 命令超時時間
        /// </summary>
        protected int? CommandTimeout { get; private set; }

        private bool _disposed = false;

        public UnitOfWorkTemplate(IDbConnection connection)
        {
            Connection = connection;
            //Connection.Open();
            //Transaction = Connection.BeginTransaction();
        }

        ~UnitOfWorkTemplate()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (Transaction != null)
                    {
                        Transaction.Dispose();
                        Transaction = null;
                    }
                    if (Connection != null)
                    {
                        Connection.Dispose();
                        Connection = null;
                    }

                    Disposing();
                }
                _disposed = true;
            }
        }

        public void Save()
        {
            try
            {
                Transaction.Commit();
            }
            catch
            {
                Transaction.Rollback();
                throw;
            }
        }

        protected virtual void Disposing() { }
    }
}
