using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DemoRepository.Dapper
{
    /// <summary>
    /// 自訂的Repository行為
    /// </summary>
    public interface IBanknoteVaultRepository : IDapperTableRepository<BanknoteVault>
    {
        IEnumerable<BanknoteVault> FindTagId(uint tagId);
    }

    public class BanknoteVaultRepository : DapperTableRepository<BanknoteVault>, IBanknoteVaultRepository
    {
        public override bool IsCreateTable => false;

        private static readonly string TAG_ID = "TagId";

        private static readonly string NUMBER_01 = "Number01";

        private static readonly string NUMBER_02 = "Number02";

        private static readonly string NUMBER_03 = "Number03";

        private static readonly string NUMBER_04 = "Number04";

        private static readonly string NUMBER_05 = "Number05";

        protected override string CreateSchemaSQL
        {
            get
            {
                return TAG_ID + " INTEGER NOT NULL," +
                       NUMBER_01 + " MEDIUMINT NOT NULL," +
                       NUMBER_02 + " MEDIUMINT NOT NULL," +
                       NUMBER_03 + " MEDIUMINT NOT NULL," +
                       NUMBER_04 + " MEDIUMINT NOT NULL," +
                       NUMBER_05 + " MEDIUMINT NOT NULL,";
            }
        }

        public BanknoteVaultRepository(IDbTransaction transaction, int? commandTimeout = null) : base(transaction, commandTimeout)
        {
        }

        public IEnumerable<BanknoteVault> FindTagId(uint tagId)
        {
            var sql = $"Select * from {TableName} Where @{TAG_ID}=?{TAG_ID}?";
            return Connection.Query<BanknoteVault>(sql, new { TagId = tagId }).AsList();
        }
    }
}
