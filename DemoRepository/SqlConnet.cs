using System.Data;
using System.Data.SqlClient;

namespace DemoRepository
{
    public static class SqlConnet
    {
		public enum DBTYPE
        {
			SQLSERVER
        }

		public static IDbConnection CreateDBConnection(DBTYPE dbType, string connectionStr)
		{
			switch (dbType)
			{
				case DBTYPE.SQLSERVER:
					return new SqlConnection(connectionStr);
				default:
					return new SqlConnection(connectionStr);
			}
		}
	}
}
