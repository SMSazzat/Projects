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

namespace StockManagementSystem
{
    public partial class StockIn : Form
    {
        public StockIn()
        {
            InitializeComponent();
        }

        Load load;
        Display display;
        Stock stock = new Stock();

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                stockInQuantityLabel.Text = "";
                if (companyComboBox.Text.Equals("--select company--")|| companyComboBox.Text.Equals(""))
                {
                    companyLabel.Text = "select company";
                    stockInQuantityTextBox.Text = "";
                    return;
                }
                if(itemComboBox.Text.Equals("--select item--")|| itemComboBox.Text.Equals(""))
                {
                    itemLabel.Text = "select item";
                    stockInQuantityTextBox.Text = "";
                    return;
                }
                if (String.IsNullOrEmpty(stockInQuantityTextBox.Text))
                {
                    stockInQuantityLabel.Text = "Enter quantity";
                    return;
                }
                int itemId = Convert.ToInt32(itemComboBox.SelectedValue);
                int stockIn = Convert.ToInt32(stockInQuantityTextBox.Text);
                if(stockIn == 0 )
                {
                    stockInQuantityLabel.Text = "stockIn quantity has to be more than 0";
                    return;
                }

                int avaliableQuantity = Convert.ToInt32(availableQuantityTextBox.Text);
                stock.StockAdd(itemId, stockIn, avaliableQuantity);
                displayDataGridView.DataSource = display.ShowStockIn(itemId);
                availableQuantityTextBox.Text = Convert.ToString(display.ShowAvailableQuantity(itemId));
                stockInQuantityTextBox.Text = "";
                stockInQuantityLabel.Text = "";

                companyComboBox.Text = "--select company--";
                categoryComboBox.Text = "--select category--";
                itemComboBox.Text = "--select item--";
                reOrderLevelTextBox.Text = " <view>";
                availableQuantityTextBox.Text = " <view>";
                MessageBox.Show("stocked In !");
            }
            catch(Exception exception)
            {
                if(exception.Message == "Input string was not in a correct format.")
                {
                    stockInQuantityLabel.Text = "stock In quantity is not valid";
                    return;
                }
                MessageBox.Show(exception.Message);
            }
          
        }

        private void itemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int itemId;
            Int32.TryParse(itemComboBox.SelectedValue.ToString(), out itemId);
            display = new Display();
            int reOrder = display.ShowReorderLevel(itemId);
            reOrderLevelTextBox.Text = Convert.ToString(reOrder);
            int availableQuantity = display.ShowAvailableQuantity(itemId);
            availableQuantityTextBox.Text = Convert.ToString(availableQuantity);

            displayDataGridView.DataSource = display.ShowStockIn(itemId);
            stockInQuantityLabel.Text = "";
            stockInQuantityTextBox.Text = "";
            itemLabel.Text = "";
           
        }

        private void StockIn_Load(object sender, EventArgs e)
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
            stockInQuantityLabel.Text = "";
            stockInQuantityTextBox.Text = "";
            displayDataGridView.DataSource = "";
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
            displayDataGridView.DataSource = "";
            stockInQuantityLabel.Text = "";
            stockInQuantityTextBox.Text = "";
                 
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            Action action = new Action();
            action.Show();
            this.Hide();
        }
    }
}
