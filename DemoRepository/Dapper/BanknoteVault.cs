using System;
using System.Collections.Generic;
using System.Text;

namespace DemoRepository.Dapper
{
    public class BanknoteVault : DapperModel
    {
        public uint TagId { get; set; }

        public ushort Number01 { get; set; }

        public ushort Number02 { get; set; }

        public ushort Number03 { get; set; }

        public ushort Number04 { get; set; }

        public ushort Number05 { get; set; }
    }
}
