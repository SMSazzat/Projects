using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.Repository
{
    class Connection
    {
        public string ConnectionString { get; set; }

        public Connection()
        {
            ConnectionString = @"server=HP-PC; Database=stock; Integrated Security=true";
        }

    }
}
