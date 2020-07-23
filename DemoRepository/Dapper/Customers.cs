using System;
using System.Collections.Generic;
using System.Text;

namespace DemoRepository.Dapper
{
    public class Customers
    {
        public long Id { get; set; }

        public string Name { get; set; }
        
        public string City { get; set; }
        
        public string Address { get; set; }

        public string Phone { get; set; }
    }
}
