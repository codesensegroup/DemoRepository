using InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFRepository
{
    public interface IEFUnitOfWork : IUnitOfWork
    {
        void StartTransaction(Action<object> action);

        TRepository GetRepository<TRepository>() where TRepository : class;
    }
}
