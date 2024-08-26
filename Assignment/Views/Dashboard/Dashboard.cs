using Assignment.Views.Car;
using Assignment.Views.Car_Part;
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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            FormLoader.LoadForm(this.mainPanel, new Assignment.Views.Dashboard.Dashboard_Panel());
        }

        public void LoadNewCarpanel()
        {
            FormLoader.LoadForm(this.mainPanel,new Assignment.Views.Car.newCarPanel());
        }

        public void LoadAllCarDetail()
        {
            FormLoader.LoadForm(this.mainPanel, new Assignment.Views.Car.ViewAllCar());
        }

        public void LoadNewPartPanel()
        {
            FormLoader.LoadForm(this.mainPanel, new NewCarPart());
        }

        public void LoadAllPartDetail() {
            FormLoader.LoadForm(this.mainPanel, new ViewAllParts());
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void adminDashboardLink_Click(object sender, EventArgs e)
        {
            FormLoader.LoadForm(this.mainPanel, new Assignment.Views.Dashboard.Dashboard_Panel());

        }

        private void carMenu_Click(object sender, EventArgs e)
        {
            CarMenu carMenu = new Assignment.Views.Car.CarMenu(this);
            FormLoader.LoadForm(this.mainPanel, carMenu);
        }

        private void partsLabel_Click(object sender, EventArgs e)
        {
            CarPartMenu partMenu = new Views.Car_Part.CarPartMenu(this);
            FormLoader.LoadForm(this.mainPanel, partMenu);
        }


        private void orderDetails_Click(object sender, EventArgs e)
        {
            FormLoader.LoadForm(this.mainPanel, new Assignment.Views.Order.OrderDetails());
        }

        private void userDetails_Click(object sender, EventArgs e)
        {
            FormLoader.LoadForm(this.mainPanel, new Assignment.Views.User.UserDetails());
        }

        private void report_Click(object sender, EventArgs e)
        {
            FormLoader.LoadForm(this.mainPanel, new Assignment.Views.Reports.OrderReportView());
        }
    }
}




//Resources 
// https://www.youtube.com/watch?v=-IppJcCABnA