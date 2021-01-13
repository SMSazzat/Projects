using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagementSystem.manager;
using StockManagementSystem.Model;

namespace StockManagementSystem
{
    public partial class StockOut : Form
    {
        public StockOut()
        {
            InitializeComponent();
           
        }
        Load load;
        Display display;
        Stock stock = new Stock();
        Data data = new Data();
        List<Data> datas = new List<Data>();
        int reOrder, availableQuantity,itemId,stockOut;
        int newAvailableQuantity;
        int isSelected;
     
        private void StockOut_Load(object sender, EventArgs e)
        {

            load = new Load();

            companyComboBox.DataSource = load.Company();
            companyComboBox.DisplayMember = "companyName";
            companyComboBox.ValueMember = "companyId";
            companyComboBox.Text = "--select company--";

            categoryComboBox.Text = "--select category--";

            itemComboBox.Text = "--select item--";
            reOrderLevelTextBox.Text = " <view>";
            availableQuantityTextBox.Text = " <view>";
            displayDataGridView.DataSource = "";

        }

        private void companyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            categoryComboBox.Text = "--select category--";
            int companyId;
            Int32.TryParse(companyComboBox.SelectedValue.ToString(), out companyId);

            DataTable dataTable;
            dataTable = load.CategoryViaCompany(companyId);

            companyLabel.Text = "";
            categoryComboBox.DataSource = dataTable;
            categoryComboBox.DisplayMember = "categoryName";
            categoryComboBox.ValueMember = "categoryId";
            categoryComboBox.Text = "--select category--";

            itemComboBox.DataSource = load.ItemViaCompany(companyId);
            itemComboBox.DisplayMember = "itemName";
            itemComboBox.ValueMember = "itemId";
            itemComboBox.Text = "--select item--";

            reOrderLevelTextBox.Text = " <view>";
            availableQuantityTextBox.Text = " <view>";
           
            if (dataTable.Rows.Count == 0)
            {
                categoryComboBox.Text = " no category found against selected company";
                itemComboBox.Text = " no item found against selected company";
            }
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            int companyId;
            int categoryId;

            Int32.TryParse(companyComboBox.SelectedValue.ToString(), out companyId);
            Int32.TryParse(categoryComboBox.SelectedValue.ToString(), out categoryId);
            itemComboBox.DataSource = load.ItemViaCompanyCategory(companyId, categoryId);
            itemComboBox.DisplayMember = "itemName";
            itemComboBox.ValueMember = "itemId";
            itemComboBox.Text = "--select item--";
            reOrderLevelTextBox.Text = " <view>";
            availableQuantityTextBox.Text = " <view>";
        }

        private void LostButton_Click(object sender, EventArgs e)
        {
            int isExecuted = stock.StockOut(itemId, stockOut, "lost", newAvailableQuantity);
            if (isExecuted > 1)
            {
                companyComboBox.Text = "--select company--";
                categoryComboBox.Text = "--select category--";
                itemComboBox.Text = "--select item--";
                reOrderLevelTextBox.Text = "";
                availableQuantityTextBox.Text = "";
                stockOutQuantityTextBox.Text = "";
                displayDataGridView.DataSource = "";
                MessageBox.Show("Item lost ");
            }
        }

        private void DamageButton_Click(object sender, EventArgs e)
        {
            int isExecuted = stock.StockOut(itemId, stockOut, "damaged", newAvailableQuantity);
            if (isExecuted > 1)
            {
                companyComboBox.Text = "--select company--";
                categoryComboBox.Text = "--select category--";
                itemComboBox.Text = "--select item--";
                reOrderLevelTextBox.Text = "";
                availableQuantityTextBox.Text = "";
                stockOutQuantityTextBox.Text = "";
                displayDataGridView.DataSource = "";
                MessageBox.Show("Item damaged ");
            }
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            Action action = new Action();
            action.Show();
            this.Hide();
        }

        private void SellButton_Click(object sender, EventArgs e)
        {
            int isExecuted = stock.StockOut(itemId, stockOut, "sold", newAvailableQuantity);
            if(isExecuted > 1)
            {
                companyComboBox.Text = "--select company--";
                categoryComboBox.Text = "--select category--";
                itemComboBox.Text = "--select item--";
                reOrderLevelTextBox.Text = "";
                availableQuantityTextBox.Text = "";
                stockOutQuantityTextBox.Text = "";
                displayDataGridView.DataSource = "";
                MessageBox.Show("Item sold ");
            }
        }

        private void itemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32.TryParse(itemComboBox.SelectedValue.ToString(), out itemId);
            display = new Display();
            reOrder = display.ShowReorderLevel(itemId);
            reOrderLevelTextBox.Text = Convert.ToString(reOrder);
            availableQuantity = display.ShowAvailableQuantity(itemId);
            availableQuantityTextBox.Text = Convert.ToString(availableQuantity);

            itemLabel.Text = "";
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                datas.Clear();
                stockOutQuantityLabel.Text = "";
                if (companyComboBox.Text.Equals("--select company--")|| companyComboBox.Text.Equals(""))
                {
                    companyLabel.Text = "select company";
                    stockOutQuantityTextBox.Text = "";
                    return;
                }
                if (itemComboBox.Text.Equals("--select item--")|| itemComboBox.Text.Equals(""))
                {
                    itemLabel.Text = "select item";
                    stockOutQuantityTextBox.Text = "";
                    return;
                }
                if (String.IsNullOrEmpty(stockOutQuantityTextBox.Text))
                {
                    stockOutQuantityLabel.Text = "Enter quantity";
                    return;
                }

                stockOut = Convert.ToInt32(stockOutQuantityTextBox.Text);
                if (stockOut == 0)
                {
                    stockOutQuantityLabel.Text = "stock Out quantity has to be more than 0";
                    return;
                }
                if (stockOut > availableQuantity)
                {
                    stockOutQuantityLabel.Text = "not enough product in stock";
                    return;
                }

                newAvailableQuantity = availableQuantity - stockOut;
                if (newAvailableQuantity <= reOrder)
                {
                    MessageBox.Show("please restock " + itemComboBox.Text);
                }

               
                data.ItemId = itemId;
                data.Item = itemComboBox.Text;
                data.Company = companyComboBox.Text;
                data.Quantity = stockOut;

                datas.Add(data);
                displayDataGridView.DataSource = "";
                displayDataGridView.DataSource = datas;
                isSelected = 1;
            }

            catch(Exception exception)
            {
                if (exception.Message == "Input string was not in a correct format.")
                    stockOutQuantityLabel.Text = "stock out quantity is not valid";
                else
                    MessageBox.Show(exception.Message);
            }
        }
    }
}
