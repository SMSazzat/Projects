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
    public partial class SearchAndView : Form
    {
        public SearchAndView()
        {
            InitializeComponent();
        }
        Load load;
        private Display display = new Display();
        private DataTable dataTable;
        private void SearchAndView_Load(object sender, EventArgs e)
        {
            load = new Load();

            companyComboBox.DataSource = load.Company();
            companyComboBox.DisplayMember = "companyName";
            companyComboBox.ValueMember = "companyId";
            companyComboBox.Text = "--select company--";
            
            categoryComboBox.DataSource = load.Category();
            categoryComboBox.DisplayMember = "categoryName";
            categoryComboBox.ValueMember = "categoryId";
            categoryComboBox.Text = "--select category--";
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if((companyComboBox.Text =="--select company--") && (categoryComboBox.Text == "--select category--"))
            {
                companyLabel.Text = "select company";
                return;
            }
            if (categoryComboBox.Text.Equals("") && companyComboBox.Text.Equals(""))
            {
                companyLabel.Text = "select company";
                return;
            }
            if ((companyComboBox.Text == "--select company--") && (categoryComboBox.Text.Length < 1))
            {
                companyLabel.Text = "select company";
                return;
            }
            if ((categoryComboBox.Text == "--select category--") && companyComboBox.Text.Length < 1)
            {
                companyLabel.Text = "select company";
                return;
            }

            int companyId = Convert.ToInt32(companyComboBox.SelectedValue);
            int categoryId = Convert.ToInt32(categoryComboBox.SelectedValue);

            if (((companyComboBox.Text == "--select company--") || (companyComboBox.Text.Length<1)) && ((categoryComboBox.Text != "--select category--") &&
                (categoryComboBox.Text != "")))
            {
                dataTable = display.ShowItemViaCategory(categoryId);
                if (dataTable.Rows.Count == 0)
                    MessageBox.Show("No product found against selected category");
                displayDataGridView.DataSource = dataTable;
                companyLabel.Text = "";
            }

            if (((categoryComboBox.Text == "--select category--") || (categoryComboBox.Text.Length<1)) && ((companyComboBox.Text != "--select company--") &&
                (companyComboBox.Text != "")))
            {
                dataTable = display.ShowItemViaCompany(companyId);
                if (dataTable.Rows.Count == 0)
                    MessageBox.Show("No product found against selected company");
                displayDataGridView.DataSource = dataTable;
                companyLabel.Text = "";
            }

            if (((companyComboBox.Text != "--select company--")&& (companyComboBox.Text != ""))&&((categoryComboBox.Text != "--select category--") && (categoryComboBox.Text != "")))
            {
               dataTable = display.ShowItemViaBoth(categoryId, companyId);
                if (dataTable.Rows.Count == 0)
                    MessageBox.Show("No product found against selected company and category");
                displayDataGridView.DataSource = dataTable;
               companyLabel.Text = "";
            }
        }

        private void companyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            displayDataGridView.DataSource = "";
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            displayDataGridView.DataSource = "";
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            Action action = new Action();
            action.Show();
            this.Hide();
        }
    }
}
