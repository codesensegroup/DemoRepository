using Dapper;
using DapperRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DemoRepository.Dapper
{
    /// <summary>
    /// 混合型(介面 + 泛型)Repository
    /// </summary>
    public interface IBanknoteVaultRepository : IDapperGenericRepository<BanknoteVault>
    {
        IEnumerable<BanknoteVault> FindTagId(uint tagId);

        //IEnumerable<BanknoteVault> FindTagId(uint tagId);
    }

    public class BanknoteVaultRepository : CustomDapperGenericRepository<BanknoteVault>, IBanknoteVaultRepository
    {
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

        public BanknoteVaultRepository(Func<IDbTransaction> transactionFactory, int? commandTimeout = null) : base(transactionFactory, commandTimeout)
        {
        }

        public IEnumerable<BanknoteVault> FindTagId(uint tagId)
        {
            var sql = $"Select * from {TableName} Where {TAG_ID}=?{TAG_ID}?";
            return Connection.Query<BanknoteVault>(sql, new { TagId = tagId }).AsList();
        }
    }
}
