using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagementSystem
{
    public partial class Action : Form
    {
        public Action()
        {
            InitializeComponent();
        }

        private void CategoryButton_Click(object sender, EventArgs e)
        {
            CategorySetup categorySetup = new CategorySetup();        
            categorySetup.Show();
            this.Hide();
        }

        private void CompanyButton_Click(object sender, EventArgs e)
        {
            CompanySetup companySetup = new CompanySetup();
            companySetup.Show();
            this.Hide();
        }

        private void ItemButton_Click(object sender, EventArgs e)
        {
            ItemSetup itemSetup = new ItemSetup();
            itemSetup.Show();
            this.Hide();
        }

        private void StockInButton_Click(object sender, EventArgs e)
        {
            StockIn stockIn = new StockIn();
            stockIn.Show();
            this.Hide();
        }

        private void StockOutButton_Click(object sender, EventArgs e)
        {
            StockOut stockOut = new StockOut();
            stockOut.Show();
            this.Hide();
        }

        private void SearchViewButton_Click(object sender, EventArgs e)
        {
            SearchAndView searchAndView = new SearchAndView();
            searchAndView.Show();
            this.Hide();
        }

        private void ViewDatesButton_Click(object sender, EventArgs e)
        {
            ViewBetweenDate viewBetweenDate = new ViewBetweenDate();
            viewBetweenDate.Show();
            this.Hide();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            this.Hide();
        }
    }
}
