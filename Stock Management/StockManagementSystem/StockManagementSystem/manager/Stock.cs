using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Repository;

namespace StockManagementSystem.manager
{
    class Stock
    {
        Save save = new Save();
        public void StockAdd(int itemId,int stockInQuantity,int availableQuantity)
        {
            save.StockAdd(itemId, stockInQuantity,availableQuantity);
        }

        public int StockOut(int itemId,int quantity,string type,int stockAvailable)
        {
            return save.StockOut(itemId, quantity, type, stockAvailable);
        }
    }
}
