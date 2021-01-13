using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace StockManagementSystem.Repository
{
    class Save
    {
        Connection connection = new Connection();
        
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        string commandString;

     
        public DataTable ShowCategory()
        {
            sqlConnection = new SqlConnection(connection.ConnectionString);
            commandString = @"SELECT ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS SL, categoryName as Name FROM categories";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            return dataTable;
        }
        public bool CategoryExist(string name)
        {
                sqlConnection = new SqlConnection(connection.ConnectionString);
                commandString = @"select *from categories where categoryName = '" + name + "'";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                sqlConnection.Close();
                if (dataTable.Rows.Count > 0)
                    return true;
                else
                    return false;
             
        }

        public DataTable SaveCategory(string name)
        {
           
                sqlConnection = new SqlConnection(connection.ConnectionString);
                commandString = @"insert into categories values('" + name + "')";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                commandString = @"SELECT ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS SL, categoryName as Name FROM categories";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                sqlConnection.Close();

                return dataTable;
           
        }

        public DataTable UpdateCategory(string name, string selectedName)
        {
            sqlConnection = new SqlConnection(connection.ConnectionString);
            commandString = @"update categories set categoryName='" + name + "' where categoryName='" + selectedName + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            int isUpdated = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            commandString = @"SELECT ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS SL, categoryName as Name FROM categories";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            return dataTable;
        }

        public DataTable CategoryLoad()
        {
            sqlConnection = new SqlConnection(connection.ConnectionString);
            commandString = @"select categoryId,categoryName from categories";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            sqlConnection.Close();

            return dataTable;

        }

        public DataTable CategoryLoadViaCompany(int companyId)
        {
            sqlConnection = new SqlConnection(connection.ConnectionString);
            commandString = @"select distinct categories.categoryId,categories.categoryName from items left join categories on items.categoryId = categories.categoryId where items.companyId = "+companyId+"";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            sqlConnection.Close();

            return dataTable;

        }

        public DataTable ShowCompany()
        {
            sqlConnection = new SqlConnection(connection.ConnectionString);
            commandString = @"SELECT ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS SL, companyName as Name FROM companies";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            return dataTable;
        }
        public bool CompanyExist(string name)
        {

            sqlConnection = new SqlConnection(connection.ConnectionString);
            commandString = @"select *from companies where companyName = '" + name + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;

        }

        public DataTable SaveCompany(string name)
        {

            sqlConnection = new SqlConnection(connection.ConnectionString);
            commandString = @"insert into companies values('" + name + "')";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            commandString = @"SELECT ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS SL, companyName as Name FROM companies";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            return dataTable;

        }

        public DataTable UpdateCompany(string name,string selectedName)
        {
            sqlConnection = new SqlConnection(connection.ConnectionString);
            commandString = @"update companies set companyName='" + name + "' where companyName='" + selectedName + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            int isUpdated = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            commandString = @"SELECT ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS SL, companyName as Name FROM companies";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            return dataTable;
        }
        
        public DataTable CompanyLoad()
        {
            sqlConnection = new SqlConnection(connection.ConnectionString);
            commandString = @"select companyId,companyName from companies";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            sqlConnection.Close();

            return dataTable;

        }

        public bool ItemExist(string name)
        {
            sqlConnection = new SqlConnection(connection.ConnectionString);
            commandString = @"select *from items where itemName = '" + name + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;

        }

        public bool ItemSave(string name,int catId,int comId,int roLevel)
        {
            sqlConnection = new SqlConnection(connection.ConnectionString);
            commandString = @"insert into items values('" + name + "'," + roLevel + ","+0+"," + comId + "," + catId + ")";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            int isSaved = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            if (isSaved > 0)
                return true;
            else
                return false;
        }

        public DataTable ItemLoadViaCompany(int comId)
        {
            sqlConnection = new SqlConnection(connection.ConnectionString);
            commandString = @"select itemName,itemId from items where companyId = "+comId+"";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            sqlConnection.Close();

            return dataTable;
        }

        public DataTable ItemLoadViaCompanyCategory(int comId,int catId)
        {
            sqlConnection = new SqlConnection(connection.ConnectionString);
            commandString = @"select itemName,itemId from items where companyId = " + comId + " and categoryId = "+catId+"";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            sqlConnection.Close();

            return dataTable;
        }

        public void StockAdd(int itemId, int stockInQuantity,int availableQuantity)
        {
            sqlConnection = new SqlConnection(connection.ConnectionString);
            int newAvailableQuantity = availableQuantity + stockInQuantity;
            commandString = @"insert into stockIn (itemId,date,stockInQuantity) values(" + itemId + ",GETDATE()," + stockInQuantity + ")";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            commandString = @"update items set availableQuantity = " + newAvailableQuantity + " where itemId = "+itemId+"";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public int StockOut(int itemId,int quantity,string type,int stockAvailable)
        {
            sqlConnection = new SqlConnection(connection.ConnectionString);
            commandString = @"insert into stockOut (itemId,date,stockOutQuantity,stockOutType) values(" + itemId + ",GETDATE()," + quantity + ",'" + type + "')";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            int isExecuted = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            commandString = @"update items set availableQuantity = " + stockAvailable + "where itemId = " + itemId + "";
            sqlCommand = new SqlCommand(commandString,sqlConnection);
            sqlConnection.Open();
            isExecuted += sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return isExecuted;

        }

    }
}
