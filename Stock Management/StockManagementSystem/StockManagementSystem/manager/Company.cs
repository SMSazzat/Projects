using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using StockManagementSystem.Repository;
using System.Threading.Tasks;

namespace StockManagementSystem.manager
{
    class Company
    {
        Save save = new Save();
        public bool CompanyExist(string name)
        {
            return save.CompanyExist(name);
        }

        public DataTable SaveCompany(string name)
        {
            return save.SaveCompany(name);
        }

        public DataTable UpdateCompany(string name,string selectedName)
        {
            return save.UpdateCompany(name,selectedName);
        }

        public DataTable ShowCompany()
        {
            return save.ShowCompany();
        }
    }
}
