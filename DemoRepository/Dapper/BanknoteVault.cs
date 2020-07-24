using System;
using System.Collections.Generic;
using System.Text;

namespace DemoRepository.Dapper
{
    public class BanknoteVault : DapperModel
    {
        public uint TagId { get; set; }

        /// <summary>
        /// 100元
        /// </summary>
        public ushort Number01 { get; set; }

        /// <summary>
        /// 200元
        /// </summary>
        public ushort Number02 { get; set; }

        /// <summary>
        /// 500元
        /// </summary>
        public ushort Number03 { get; set; }

        /// <summary>
        /// 1000元
        /// </summary>
        public ushort Number04 { get; set; }

        /// <summary>
        /// 2000元
        /// </summary>
        public ushort Number05 { get; set; }
    }
}
