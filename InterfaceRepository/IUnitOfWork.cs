using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceRepository
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 儲存
        /// </summary>
        void Save();
    }
}
