using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment.Views
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void NewAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Assignment.Views.Register.Register registerForm = new Assignment.Views.Register.Register();
            // Show the Register form
            registerForm.Show();

            // Hide the current Login form
            this.Hide();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = UserNameBox.Text.Trim();
            string password = PasswordBox.Text.Trim();  

            if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please Enter Both Username and Password", "Login Error");
                return;
            }
            (bool success,Assignment.Models.IUser user,string message) =Assignment.DatabaseConnection.Authenticateuser(username,password);

            if (success) {
                MessageBox.Show($"Welocme,{user.FirstName} {user.LastName}!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (user.Username == "admin")
                {
                    Assignment.Views.Dashboard.Dashboard adminDashboard = new Assignment.Views.Dashboard.Dashboard();
                    adminDashboard.Show();
                    this.Hide();
                }
                else
                {
                    Assignment.Views.Dashboard.CustomerDashboard customerDashboard = new Dashboard.CustomerDashboard(user);
                    customerDashboard.Show();
                    this.Hide();
                }
            
            }
        }
    }
}
