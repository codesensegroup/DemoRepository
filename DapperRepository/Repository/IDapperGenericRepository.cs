﻿using InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperRepository
{
    public interface IDapperGenericRepository<TEntity> : IGenericRepository<TEntity>
     where TEntity : class, new()
    {
        // 預留定義其他常用的功能介面
        // 或使用Extension類別擴充
    }
}
