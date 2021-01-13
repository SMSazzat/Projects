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
    public partial class CategorySetup : Form
    {
        public CategorySetup()
        {
            InitializeComponent();
        }
        Category category;
        string selectedName;
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(categoryNameTextBox.Text))
            {
                categoryNameLabel.Text = "Field can not be empty !";
                return;
            }

            try
            {
                string categoryName = categoryNameTextBox.Text;
                
                bool exist = category.CategoryExist(categoryName);
                if (exist)
                {
                    categoryNameLabel.Text = "Category exists!";
                    categoryNameTextBox.Text = "";
                    SaveButton.Text = "Save";
                    return;
                }

                if (SaveButton.Text.Equals("Update"))
                {
                    categoryGridView.DataSource = category.UpdateCategory(categoryName, selectedName);
                    categoryNameTextBox.Text = "";
                    SaveButton.Text = "Save";
                    MessageBox.Show("category updated");

                }
                else
                    categoryGridView.DataSource = category.SaveCategory(categoryName);

                categoryNameLabel.Text = "";
                categoryNameTextBox.Text = "";
                SaveButton.Text = "Save";
                MessageBox.Show("category saved");

            }

           catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        
        private void categoryGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.categoryGridView.Rows[e.RowIndex];
                categoryNameTextBox.Text = row.Cells["Name"].Value.ToString();
                SaveButton.Text = "Update";
                selectedName = categoryNameTextBox.Text;
                categoryNameLabel.Text = "";
            }

        }

        private void CategorySetup_Load(object sender, EventArgs e)
        {
            category = new Category();
            categoryGridView.DataSource = category.ShowCategory();
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            Action action = new Action();
            action.Show();
            this.Hide();
        }
    }
}
