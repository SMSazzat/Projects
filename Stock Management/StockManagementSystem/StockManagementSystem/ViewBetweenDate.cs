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
    public partial class ViewBetweenDate : Form
    {
        public ViewBetweenDate()
        {
            InitializeComponent();
        }

        Display display = new Display();
        DataTable dataTable = new DataTable();

        private void SearchButton_Click(object sender, EventArgs e)
        {
            displayDataGridView.DataSource = "";
            DateTime from = fromDTP.Value;
            DateTime to = toDTP.Value;

            int result = DateTime.Compare(from, to);
            if (result > 0)
            {
                fromDateLabel.Text = "From date has to be earlier than to date";
                return;
            }
            DateTime now = DateTime.Now;
            result = DateTime.Compare(from,now);
            if (result > 0)
            {
                fromDateLabel.Text = "From date has to be less than today";
                return;
            }
            result = DateTime.Compare(to.Date, now.Date);
            if (result > 0)
            {
                toDateLabel.Text = "to date exceed current date";
                return;
            }

            string whoChecked = "";
            if (soldRadioButton.Checked)
                whoChecked = "sold";
            if (lostRadioButton.Checked)
                whoChecked = "lost";
            if (damagedRadioButton.Checked)
                whoChecked = "damaged";

            dataTable = display.ShowItemViaDate(from,to,whoChecked);
           
            if (dataTable.Rows.Count == 0)
                MessageBox.Show("No product "+whoChecked+" within this period");
            else
                displayDataGridView.DataSource = dataTable;

            fromDateLabel.Text = "";
            toDateLabel.Text = "";
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            Action action = new Action();
            action.Show();
            this.Hide();
        }
    }
}
