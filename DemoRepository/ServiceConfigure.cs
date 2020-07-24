using DapperRepository;
using DemoRepository.Dapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DemoRepository
{
    public static class ServiceConfigure
    {
        private static ServiceProvider _provider;

        public static ServiceProvider GetProvider()
        {
            if (_provider is null) _provider = CreateServiceProvider();
            return _provider;
        }

        private static ServiceProvider CreateServiceProvider()
        {
            var collection = new ServiceCollection();

            // SQLite宣告
            collection.AddScoped<IDbFactory, SQLiteDbFactory>(_ =>
            {
                return new SQLiteDbFactory("Data Source=SQLitedb.db; Version=3;");
            });

            // SQL宣告
            //collection.AddScoped<IDbFactory, SqlDbFactory>(_ =>
            //{
            //    return new SqlDbFactory("Server=I29042\\WINCC;Database=TEST;user=sa;password=laser99;");
            //});

            // 創建IDbConnection
            collection.AddTransient(c => c.GetService<IDbFactory>().Create());
            collection.AddTransient<IDapperGenericRepository<Customers>>(c => new DapperGenericRepository<Customers>(c.GetService<IDbConnection>()));

            // 創建Demo用的Dapper
            collection.AddScoped<DemoDapper>();

            return collection.BuildServiceProvider();
        }
    }

}
