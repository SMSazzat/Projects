using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using StockManagementSystem.Repository;

namespace StockManagementSystem.manager
{
    class Load
    {
        Save save = new Save();
        public DataTable Category()
        {
            return save.CategoryLoad();
        }

        public DataTable Company()
        {
            return save.CompanyLoad();
        }

        public DataTable ItemViaCompany(int comId)
        {
            return save.ItemLoadViaCompany(comId);
        }

        public DataTable ItemViaCompanyCategory(int comId,int catId)
        {
            return save.ItemLoadViaCompanyCategory(comId,catId);
        }
        public DataTable CategoryViaCompany(int companyId)
        {
            return save.CategoryLoadViaCompany(companyId);
        }
    }
}
