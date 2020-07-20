using InterfaceRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EFRepository
{
    public abstract class BaseEFUnitOfWork : IUnitOfWork
    {
        protected DbContext Context { get; private set; }

        private bool _disposed = false;

        public BaseEFUnitOfWork(DbContext context)
        {
            Context = context;
        }

        ~BaseEFUnitOfWork()
        {
            Dispose(false);
        }
         
        public virtual void Save()
        {
            Context.SaveChanges();
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
                    if (Context != null)
                    {
                        Context.Dispose();
                        Context = null;
                    }

                    Disposing();
                }
                _disposed = true;
            }
        }

        protected virtual void Disposing() { }
    }


    public class EFUnitOfWork : BaseEFUnitOfWork, IEFUnitOfWork
    {
        private Hashtable Repositories { get; set; } = new Hashtable();

        public EFUnitOfWork(DbContext context) : base(context)
        {
        }

        public override void Save()
        {
            // TODO 可以在儲存前，先檢查Model是否合法化

            base.Save();
        }

        public void StartTransaction(Action<object> action)
        {
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    action?.Invoke(this);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public TRepository GetRepository<TRepository>() where TRepository : class
        {
            var type = typeof(TRepository);
            var typeName = type.Name;

            if (!Repositories.ContainsKey(typeName))
            {
                var repositoryInstance = Activator.CreateInstance(type, Context);
                Repositories.Add(typeName, repositoryInstance);
            }

            return (TRepository)Repositories[typeName];
        }

        protected override void Disposing()
        {
            Repositories.Clear();
            Repositories = null;
        }
    }
}
