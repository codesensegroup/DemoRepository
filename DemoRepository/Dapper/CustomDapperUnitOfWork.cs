using DapperRepository;
using InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DemoRepository.Dapper
{
    /// <summary>
    /// 介面型的Unit of work
    /// </summary>
    public interface ICustomDapperUnitOfWork : IUnitOfWork
    {
        IBanknoteVaultRepository BanknoteVaultRepository { get; }
    }

    public class CustomDapperUnitOfWork : UnitOfWorkTemplate, ICustomDapperUnitOfWork
    {
        private IBanknoteVaultRepository _banknoteVaultRepository;

        public CustomDapperUnitOfWork(IDbConnection connection) : base(connection)
        {
        }

        public IBanknoteVaultRepository BanknoteVaultRepository => throw new NotImplementedException();

        // 這邊有兩種方式
        // (1) 使用DI Property注入的方式
        // public IBanknoteVaultRepository BanknoteVaultRepository { get; set; }

        // (2) 自行宣告Repository
        //public IBanknoteVaultRepository BanknoteVaultRepository => _banknoteVaultRepository ?? (_banknoteVaultRepository = new BanknoteVaultRepository(Transaction));
    }
}
