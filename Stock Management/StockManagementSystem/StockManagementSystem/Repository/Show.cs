using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.Repository
{
    class Show
    {
        Connection connection = new Connection();
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        string commandString;

        public int ShowReorderLevel(int itemId)
        {
            int reorderLevel = 0;
            sqlConnection = new SqlConnection(connection.ConnectionString);
            commandString = @"select reorderLevel from items where itemId = " + itemId + "";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
                reorderLevel = (int)sqlDataReader["reorderLevel"];

            sqlDataReader.Close();
            sqlConnection.Close();
            return reorderLevel;
        }

        public int ShowAvailableQuantity(int itemId)
        {
            int availableQuantity = 0;
            sqlConnection = new SqlConnection(connection.ConnectionString);
            commandString = @"select availableQuantity from items where itemId = " + itemId + "";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
                availableQuantity = (int)sqlDataReader["availableQuantity"];

            sqlDataReader.Close();
            sqlConnection.Close();

            return availableQuantity;
            
        }

        public DataTable ShowStockIn(int itemId)
        {
            sqlConnection = new SqlConnection(connection.ConnectionString);
            commandString = @"select ROW_NUMBER()over(order by (select 1)desc)as SL,itemName as Item,date as Date,stockInQuantity as Quantity from stockIn left join items
on items.itemId = stockIn.itemId where items.itemId = "+itemId+" order by stockInId desc";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }

        public DataTable ShowItemViaCategory(int categoryId)
        {
            sqlConnection = new SqlConnection(connection.ConnectionString);
            commandString = @"select ROW_NUMBER()over(order by (select 1))as SL,itemName as Item,companyName as Company,categoryName  as Category,availableQuantity as AvailableQuantity,reorderLevel as ReorderLevel from items left join companies
on items.companyId  = companies .companyId left join categories on items.categoryId = categories.categoryId where items.categoryId = "+ categoryId + "";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
            
        }

        public DataTable ShowItemViaCompany(int companyId)
        {
            sqlConnection = new SqlConnection(connection.ConnectionString);
            commandString = @"select ROW_NUMBER()over(order by (select 1))as SL,itemName as Item,companyName as Company,categoryName  as Category,availableQuantity as AvailableQuantity,reorderLevel as ReorderLevel from items left join companies
on items.companyId  = companies .companyId left join categories on items.categoryId = categories.categoryId where items.companyId =" + companyId + "";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;

        }

        public DataTable ShowItemViaBoth(int categoryId,int companyId)
        {
            sqlConnection = new SqlConnection(connection.ConnectionString);
            commandString = @"select ROW_NUMBER()over(order by (select 1))as SL,itemName as Item,companyName as Company,categoryName  as Category,availableQuantity as AvailableQuantity,reorderLevel as ReorderLevel from items left join companies
on items.companyId  = companies .companyId left join categories on items.categoryId = categories.categoryId where items.companyId = " + companyId + " and items.categoryId="+categoryId+"";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;

        }

        public DataTable ShowItemViaDate(DateTime from, DateTime to, string type)
        {
            sqlConnection = new SqlConnection(connection.ConnectionString);
            if(type == "sold")
            commandString = @"select ROW_NUMBER()over(order by (select 1))as SL,itemName as Item, companyName as Company,stockOutQuantity
as Quantity, stockOutType as StockOutType from stockOut join items on items.itemId = stockOut.itemId join companies on 
items.companyId = companies.companyId where stockOutType = 'sold' and date between '"+from+"'and '"+to+"'";

            if (type == "lost")
                commandString = @"select ROW_NUMBER()over(order by (select 1))as SL,itemName as Item, companyName as Company,stockOutQuantity
as Quantity, stockOutType as StockOutType from stockOut join items on items.itemId = stockOut.itemId join companies on 
items.companyId = companies.companyId where stockOutType = 'lost' and date between '" + from + "'and'" + to + "'";

            if (type == "damaged")
                commandString = @"select ROW_NUMBER()over(order by (select 1))as SL,itemName as Item, companyName as Company,stockOutQuantity
as Quantity, stockOutType as StockOutType from stockOut join items on items.itemId = stockOut.itemId join companies on 
items.companyId = companies.companyId where stockOutType = 'damaged' and date between '" + from + "'and '" + to + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;

        }

    }
}
