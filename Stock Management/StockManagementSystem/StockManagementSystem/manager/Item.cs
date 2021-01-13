using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Repository;

namespace StockManagementSystem.manager
{
    class Item
    {
        Save save = new Save();
        public bool ItemExist(string item)
        {
            return save.ItemExist(item);
        }

        public bool ItemSave(string name, int catId, int comId, int roLevel)
        {
            return save.ItemSave(name, catId, comId, roLevel);
        }
    }
}
