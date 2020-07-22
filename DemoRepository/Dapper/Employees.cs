using System;
using System.Collections.Generic;
using System.Text;

namespace DemoRepository.Dapper
{
    public class Employees : DapperModel
    {
        public string Name { get; set; }

        public string Title { get; set; }
    }
}
