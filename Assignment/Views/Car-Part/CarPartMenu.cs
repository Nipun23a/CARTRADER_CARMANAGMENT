using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment.Views.Car_Part
{
    public partial class CarPartMenu : Form
    {
        private Assignment.Views.Dashboard.Dashboard dashboard;
        public CarPartMenu(Assignment.Views.Dashboard.Dashboard dashboardInstance = null)
        {
            InitializeComponent();
            dashboard = dashboardInstance;

        }

        private void addNewPartButton_Click(object sender, EventArgs e)
        {
            dashboard.LoadNewPartPanel();
        }

        private void partsButton_Click(object sender, EventArgs e)
        {
            dashboard.LoadAllPartDetail();
        }
    }
}
