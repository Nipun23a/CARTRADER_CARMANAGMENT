using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment.Views.Car
{
    public partial class CarMenu : Form
    {
        private Assignment.Views.Dashboard.Dashboard dashboard;
        public CarMenu(Assignment.Views.Dashboard.Dashboard dashboardInstance = null)
        {
            InitializeComponent();
            dashboard = dashboardInstance;
        }

        private void addnewCarButton_Click(object sender, EventArgs e)
        {
            dashboard.LoadNewCarpanel();

        }

        private void viewCarDetailsButton_Click(object sender, EventArgs e)
        {
            dashboard.LoadAllCarDetail();
        }
    }
}
