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
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private string userName = "admin";
        private string password = "1234";

        Action action = new Action();
        private void LogInButton_Click(object sender, EventArgs e)
        {
            if (userNameTextBox.Text.Length == 0)
                userNameLabel.Text = "Enter userName";
            if (userNameTextBox.Text.Length > 0 && userNameTextBox.Text != userName)
                userNameLabel.Text = "userName is not valid";
            if (passwordTextBox.Text.Length == 0)
                passwordLabel.Text = "Enter password";
            if (passwordTextBox.Text.Length > 0 && passwordTextBox.Text != password)
                passwordLabel.Text = "Wrong password";

            if (userNameTextBox.Text == userName && passwordTextBox.Text == password)
            {
                userNameTextBox.Text = "";
                passwordTextBox.Clear();
                userNameLabel.Text = "";
                passwordLabel.Text = "";
                action.Show();
                this.Hide();
            }
        }
    }
}
