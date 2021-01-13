using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using StockManagementSystem.manager;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagementSystem
{
    public partial class ItemSetup : Form
    {
        Load load;
        public ItemSetup()
        {
            InitializeComponent();

        }

        
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(categoryComboBox.Text.Equals("--select category--")|| categoryComboBox.Text.Equals(""))
            {
                categoryLabel.Text = "select a category";
                return;
            }
            if(companyComboBox.Text.Equals("--select company--")|| companyComboBox.Text.Equals(""))
            {
                companyLabel.Text = "select a company";
                return;
            }
            if(String.IsNullOrEmpty(itemNameTextBox.Text))
            {
                itemNameLabel.Text = "Field can not be empty !";
                return;
            }
            if (!itemNameTextBox.Text.Equals(""))
                itemNameLabel.Text = "";
            if (String.IsNullOrEmpty(reorderLevelTextBox.Text))
            {
                reorderLabel.Text = "enter reorder level value";
                return;
            }
            int num = 1;
            string input = reorderLevelTextBox.Text;
            if (!int.TryParse(input, out num))
            {
                reorderLabel.Text = "reorder level value has to be an integer";
                return;
            }
            

            try
            {
                string itemName = itemNameTextBox.Text;
                Item item = new Item();
                bool exist = item.ItemExist(itemName);
                if(exist)
                {
                    itemNameLabel.Text = "Item exist !";
                    return;
                }
                else
                {
                    string name = itemNameTextBox.Text;
                    int categoryId = Convert.ToInt32(categoryComboBox.SelectedValue);
                    int companyId = Convert.ToInt32(companyComboBox.SelectedValue);
                    int reorderLevel = Convert.ToInt32(reorderLevelTextBox.Text);

                    bool isSaved = item.ItemSave(name, categoryId, companyId, reorderLevel);
                    if (isSaved)
                    {
                        categoryComboBox.Text = "--select category--";
                        companyComboBox.Text = "--select company--";
                        itemNameLabel.Text = "";
                        itemNameTextBox.Text = "";
                        reorderLevelTextBox.Text = "";
                        //reorderLabel.Text = "";
                        MessageBox.Show("Item added");
                    }

                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ItemSetup_Load(object sender, EventArgs e)
        {
            load = new Load();

            categoryComboBox.DataSource = load.Category();
            categoryComboBox.DisplayMember = "categoryName";
            categoryComboBox.ValueMember = "categoryId";
            categoryComboBox.Text = "--select category--";

            companyComboBox.DataSource = load.Company();
            companyComboBox.DisplayMember = "companyName";
            companyComboBox.ValueMember = "companyId";
            companyComboBox.Text = "--select company--";

            if((categoryComboBox.Text == "--select category--")|| (companyComboBox.Text == "--select company--"))
            {
                reorderLevelTextBox.Text = "";
            }
            
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            categoryLabel.Text = "";
            itemNameLabel.Text = "";
            reorderLevelTextBox.Text = "0";
        }

        private void companyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            companyLabel.Text = "";
            itemNameLabel.Text = "";
            reorderLevelTextBox.Text = "0";
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            Action action = new Action();
            action.Show();
            this.Hide();
        }
    }
}
