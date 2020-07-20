using DapperRepository;
using DemoRepository.Dapper;
using DemoRepository.EF;
using EFRepository;
using System;
using System.Data;

namespace DemoRepository
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


        public static void DemoDapper()
        {
            // TODO 等待完成 使用連線注入(可以是SQL或SQLite等等)
            IDbConnection connection = null;

            using (var uow = new DapperUnitOfWork(connection))
            {
                var banknoteVaultRepository = uow.GetRepository<IBanknoteVaultRepository>();

                // 找尋資料
                var vault = banknoteVaultRepository.FindTagId(1);

                // 儲存資料
                uow.Save();
            }

            using (var uow = new CustomDapperUnitOfWork(connection))
            {
                var vault = uow.BanknoteVaultRepository.FindTagId(1);

                // 儲存資料
                uow.Save();
            }

        }

        public static void DemoEF()
        {
            // TODO 等待完成
            ApplicationDbContext context = null;

            // 可以使用DI注入
            using (var uow = new EFUnitOfWork(context))
            {

                // 等待完成
                // uow.GetRepository<>


                uow.Save();
            }
        }
    }
}
