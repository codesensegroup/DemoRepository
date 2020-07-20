using InterfaceRepository;
using System;

namespace DapperRepository
{
    /// <summary>
    /// 自動產生泛型類別
    /// </summary>
    public interface IDapperUnitOfWork : IUnitOfWork
    {
        TRepository GetRepository<TRepository>() where TRepository : class;
    }
}
