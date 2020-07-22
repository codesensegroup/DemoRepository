using DapperRepository;
using DemoRepository.Dapper;
using DemoRepository.EF;
using EFRepository;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DemoRepository
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            DemoDapper();
        }


        public static void DemoDapper()
        {

            // TODO 等待完成 使用連線注入(可以是SQL或SQLite等等)
            IDbConnection connection = SqlConnet.CreateDBConnection(SqlConnet.DBTYPE.SQLSERVER, 
                                                                   "Server=I29042\\WINCC;Database=TEST;user=sa;password=laser99;");

            using (var uow = new DapperUnitOfWork(connection))
            {
                //// 介面型 + 泛型 (混搭)
                //var banknoteVaultRepository = uow.GetRepository<IBanknoteVaultRepository>();
                //var vaults = banknoteVaultRepository.FindTagId(1);   // 找尋資料
                //var vault = new BanknoteVault()
                //{
                //    TagId = 10000,
                //    Number01 = 1,
                //    Number02 = 2,
                //    Number03 = 3,
                //    Number04 = 4,
                //    Number05 = 5,
                //};

                //banknoteVaultRepository.Add(vault);                 // 新增資料
                //vault.Number01 += 10;
                //banknoteVaultRepository.Update(vault);              // 更新資料
                //banknoteVaultRepository.Remove(vault);              // 刪除資料


                // 介面型
                var memberRepository = uow.GetRepository<IMemberRepository>();
                //memberRepository.Add()
                //memberRepository.Read()

                // 泛型 (同上方)
                var employeesRepository = uow.GetGenericRepository<Employees>();

                // 儲存資料
                uow.Save();
            }

            using (var uow = new DapperCustomUnitOfWork(connection))
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
