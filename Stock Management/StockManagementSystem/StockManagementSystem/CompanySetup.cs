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
    public partial class CompanySetup : Form
    {
        public CompanySetup()
        {
            InitializeComponent();
        }

        Company company;
        string selectedName;

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(companyNameTextBox.Text))
            {
                companyNameLabel.Text = "Field can not be empty !";
                return;
            }
            try
            {
                string companyName = companyNameTextBox.Text;
                
                bool exist = company.CompanyExist(companyName);
                if (exist)
                {
                    companyNameLabel.Text = "Company exists!";
                    companyNameTextBox.Text = "";
                    SaveButton.Text = "Save";
                    return;
                }
                if(SaveButton.Text.Equals("Update"))
                {
                    companyGridView.DataSource = company.UpdateCompany(companyName, selectedName);
                    companyNameTextBox.Text = "";
                    SaveButton.Text = "Save";
                    MessageBox.Show("company updated");

                }
                else
                    companyGridView.DataSource = company.SaveCompany(companyName);

                companyNameLabel.Text = "";
                companyNameTextBox.Text = "";
                MessageBox.Show("company saved");
                

            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        
        private void companyGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.companyGridView.Rows[e.RowIndex];
                companyNameTextBox.Text = row.Cells["Name"].Value.ToString();
                SaveButton.Text = "Update";
                selectedName = companyNameTextBox.Text;
                companyNameLabel.Text = "";
            }
        }

        private void CompanySetup_Load(object sender, EventArgs e)
        {
            company = new Company();
            companyGridView.DataSource = company.ShowCompany();
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            Action action = new Action();
            action.Show();
            this.Hide();
        }
    }
}
