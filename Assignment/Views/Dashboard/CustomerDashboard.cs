using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment.Views.Dashboard
{
    public partial class CustomerDashboard : Form
    {
        private Assignment.Models.IUser currentUser;
        public CustomerDashboard(Assignment.Models.IUser user)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            currentUser = user;
        }


        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void adminDashboardLink_Click(object sender, EventArgs e)
        {
            FormLoader.LoadForm(this.mainPanel, new Assignment.Views.Dashboard.CustomerDashboardPanel());
        }

        private void orderItem_Click(object sender, EventArgs e)
        {
            FormLoader.LoadForm(this.mainPanel, new Assignment.Views.Search.SearchView(currentUser));
        }

        private void orderDetails_Click(object sender, EventArgs e)
        {
            FormLoader.LoadForm(this.mainPanel, new Assignment.Views.Order.CustomerOrderDetails(currentUser));
        }
    }
}
