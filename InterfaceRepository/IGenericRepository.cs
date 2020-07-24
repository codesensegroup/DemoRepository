using System;
using System.Linq;

namespace InterfaceRepository
{
    public interface IGenericRepository<TEntity>
       where TEntity : class, new()
    {
        /// <summary>
        /// 新增物件
        /// </summary>
        void Add(TEntity entity);

        /// <summary>
        /// 新增物件         
        /// </summary>
        void AddRange(params TEntity[] entities);

        /// <summary>
        /// 讀取資料
        /// </summary>
        IQueryable<TEntity> ReadRange();

        /// <summary>
        /// 更新物件
        /// </summary>
        void Update(TEntity entity);

        /// <summary>
        /// 更新大量的物件
        /// </summary>
        void UpdateRange(params TEntity[] entities);

        /// <summary>
        /// 刪除物件
        /// </summary>
        void Remove(TEntity entity);

        /// <summary>
        /// 刪除大量的物件
        /// </summary>
        void RemoveRange(params TEntity[] entities);
    }
}
