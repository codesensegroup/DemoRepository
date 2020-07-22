using Dapper;
using DapperRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DemoRepository.Dapper
{
    /// <summary>
    /// 泛型版本，(限制的IDapperModel，可以插入時，同時新增、更新時間)
    /// </summary>
    public class DapperGenericRepository<TEntity> : DapperRepository.DapperGenericRepository<TEntity>, IDapperGenericRepository<TEntity>
        where TEntity : class, IDapperModel, new()
    {
        /// <summary>
        /// 是否創建資料表
        /// </summary>
        public virtual bool IsCreateTable => true;

        protected static readonly string ID = "Id";

        protected static readonly string UPDATE_TIME = "UpdateTime";

        protected static readonly string INSERT_TIME = "InsertTime";

        /// 取得表格名稱
        /// </summary>
        public virtual string TableName => typeof(TEntity).Name;

        public DapperGenericRepository(IDbTransaction transaction, int? commandTimeout = null) : base(transaction, commandTimeout)
        {
            if (IsCreateTable) Connection.Execute(GetCreateTableSQL());
        }

        public override void Add(TEntity entity)
        {
            entity.InitTime();
            base.Add(entity);
        }

        public override void AddRange(params TEntity[] entities)
        {
            foreach (var entity in entities)
            {
                entity.InitTime();
            }
            base.AddRange(entities);
        }

        public override void Update(TEntity entity)
        {
            entity.UpdateTime();
            base.Update(entity);
        }

        public override void UpdateRange(params TEntity[] entities)
        {
            foreach (var entity in entities)
            {
                entity.UpdateTime();
            }

            base.UpdateRange(entities);
        }

        public virtual string GetCreateTableSQL()
        {
            return "CREATE TABLE IF NOT EXISTS " + TableName + " (" +
                 ID + " INTEGER PRIMARY KEY AUTOINCREMENT," +
                 CheckCreateSchemaSQL() +
                 UPDATE_TIME + " DATETIME DEFAULT 'default current_timestamp'," +
                 INSERT_TIME + " DATETIME DEFAULT 'default current_timestamp'" +
            ")";
        }

        private string CheckCreateSchemaSQL()
        {
            return CreateSchemaSQL.EndsWith(",") ? CreateSchemaSQL : (CreateSchemaSQL + ",");
        }

        /// <summary>
        /// 取得創建表格內的屬性欄位
        /// </summary>
        protected virtual string CreateSchemaSQL => string.Empty;
    }
}
