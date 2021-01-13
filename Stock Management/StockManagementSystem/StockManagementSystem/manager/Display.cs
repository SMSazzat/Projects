using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Repository;

namespace StockManagementSystem.manager
{
    class Display
    {
        Show show = new Show();
        public int ShowReorderLevel(int itemId)
        {
            return show.ShowReorderLevel(itemId);
        }

        public int ShowAvailableQuantity(int itemId)
        {
            return show.ShowAvailableQuantity(itemId);
        }

        public DataTable ShowStockIn(int itemId)
        {
            return show.ShowStockIn(itemId);
        }

        public DataTable ShowItemViaCategory(int categoryId)
        {
            return show.ShowItemViaCategory(categoryId);
        }

        public DataTable ShowItemViaCompany(int companyId)
        {
            return show.ShowItemViaCompany(companyId);
        }

        public DataTable ShowItemViaBoth(int categoryId,int companyId)
        {
            return show.ShowItemViaBoth(categoryId,companyId);
        }

        public DataTable ShowItemViaDate(DateTime from, DateTime to, string type)
        {
            return show.ShowItemViaDate(from, to, type);
        }

    }
}
