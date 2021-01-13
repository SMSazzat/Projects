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
    class Category
    {
        Save save = new Save();
        public bool CategoryExist(string name)
        {
            return save.CategoryExist(name);
        }
        public DataTable SaveCategory(string name)
        {
           return save.SaveCategory(name);
        }
        public DataTable UpdateCategory(string name, string selectedName)
        {
            return save.UpdateCategory(name, selectedName);
        }
       public DataTable ShowCategory()
        {
            return save.ShowCategory();
        }
    }
}
