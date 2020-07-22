using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Text;

namespace DemoRepository
{
    public interface IDbFactory
    {
        IDbConnection Create();
    }

    public class SQLiteDbFactory : IDbFactory
    {
        private string ConnectString { get; set; }

        public SQLiteDbFactory(string connectString)
        {
            ConnectString = connectString;
        }

        public IDbConnection Create()
        {
            return new SQLiteConnection(ConnectString);
        }
    }

    public class SqlDbFactory : IDbFactory
    {
        private string ConnectString { get; set; }

        public SqlDbFactory(string connectString)
        {
            ConnectString = connectString;
        }

        public IDbConnection Create()
        {
            return new SqlConnection(ConnectString);
        }
    }
}
