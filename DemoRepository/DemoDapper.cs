using Dapper;
using DapperRepository;
using DemoRepository.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DemoRepository
{
    public class DemoDapper
    {
        private readonly IDbConnection _connection;

        public DemoDapper(IDbConnection connection)
        {
            _connection = connection;
            CreateMember();
            CreateEmployees();
        }

        public void Demo()
        {
            using (var uow = new DapperUnitOfWork(_connection))
            {
                #region --- 第一次交易 ---
                // 介面型 + 泛型 (混搭)
                var banknoteVaultRepository = uow.GetRepository<IBanknoteVaultRepository>();
                var vault = new BanknoteVault()
                {
                    TagId = 10000,
                    Number01 = 1,
                    Number02 = 2,
                    Number03 = 3,
                    Number04 = 4,
                    Number05 = 5,
                };
                banknoteVaultRepository.Add(vault);                 // 新增資料
                vault.Number01 += 10;
                banknoteVaultRepository.Update(vault);              // 更新資料

                // 新增資料
                var findVault = banknoteVaultRepository.FindTagId(10000);

                // 介面型
                var memberRepository = uow.GetRepository<IMemberRepository>();
                var member = new Member
                {
                    Name = "Frank",
                    Age = 28,
                    Phone = "123456789",
                    Address = "Hello"
                };
                memberRepository.Add(member);

                // 泛型 (同上方)
                var employeesRepository = uow.GetGenericRepository<Employees>();
                var employees = new Employees()
                {
                    Name = "Darren",
                    Title = "SoftWare Engineer"
                };
                employeesRepository.Add(employees);

                // 儲存資料
                uow.Save();
                #endregion

                #region --- 第二次交易 ---
                member = new Member
                {
                    Name = "Jimpo",
                    Age = 18,
                    Phone = "1222",
                    Address = "Hello~"
                };

                memberRepository.Add(member);

                employees = new Employees()
                {
                    Name = "1K",
                    Title = "SoftWare Engineer"
                };
                employeesRepository.Add(employees);

                // 儲存資料
                uow.Save();
                #endregion

                #region --- 第三次交易(失敗) ---
                // 故意測試，此筆交易是否會成功
                //var employeesRepositoryNew = uow.GetGenericRepository<Employees>();
                employeesRepository.Add(new Employees() { Name = "Mario", Title = "Engineer" });
                throw new Exception("Don't save the Member and Employees.");

                // 儲存資料
                uow.Save();
                #endregion
            }
        }

        private void CreateEmployees()
        {
            var sql = "CREATE TABLE IF NOT EXISTS Employees(Id INTEGER PRIMARY KEY AUTOINCREMENT, Name VARCHAR(30) NOT NULL, Title VARCHAR(30) NOT NULL, UpdateTime DATETIME DEFAULT 'default current_timestamp', InsertTime DATETIME DEFAULT 'default current_timestamp')";
            _connection.Execute(sql);
        }

        private void CreateMember()
        {
            var sql = "CREATE TABLE IF NOT EXISTS Member(Id INTEGER PRIMARY KEY AUTOINCREMENT, Name VARCHAR(30) NOT NULL, Age TINYINT NOT NULL, Phone VARCHAR(30) NOT NULL, Address VARCHAR(30) NOT NULL)";
            _connection.Execute(sql);
        }
    }
}
