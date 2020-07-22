using DapperRepository;
using DemoRepository.Dapper;
using DemoRepository.EF;
using EFRepository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DemoRepository
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = ServiceConfigure.GetProvider();
            var demoDapper = provider.GetService<DemoDapper>();
            demoDapper.Demo();

            Console.ReadKey();
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
