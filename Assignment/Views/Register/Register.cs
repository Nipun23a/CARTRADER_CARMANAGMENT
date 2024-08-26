using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Assignment.Views.Register
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();

            this.Close();


        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            // Retrieve input from the text boxes
            string firstName = firstNameTextBox.Text.Trim();
            string lastName = lastNameTextBox.Text.Trim();
            string username = userNameTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();
            string confirmPassword = confirmPasswordTextBox.Text.Trim();
            string email = emailTextBox.Text.Trim();

            // Validate the input
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please fill in all fields.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create a new User object
            Assignment.Models.IUser newUser = new Assignment.Models.User 
            {
                FirstName = firstName,
                LastName = lastName,
                Username = username,
                Password = password, 
                Email = email
            };

            // Register the user
            var result = DatabaseConnection.RegisterUser(newUser);

            // Handle the response
            if (result.Success)
            {
                MessageBox.Show(result.Message, "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Assignment.Views.Login login = new Assignment.Views.Login();
                login.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(result.Message, "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
