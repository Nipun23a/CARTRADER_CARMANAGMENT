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
    public partial class NewCarPart : Form
    {
        public NewCarPart()
        {
            InitializeComponent();
        }

        private void addCarPartButton_Click(object sender, EventArgs e)
        {
            string name = carPartNameTextBox.Text.Trim();
            string description = descriptionTextBox.Text.Trim();
            double price = Convert.ToDouble(priceBox.Value);
            int stockQuantity = Convert.ToInt32(stockBox.Value);

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description) || (price <= 0.00) || (stockQuantity <= 0))
            {
                MessageBox.Show("Please fill in all fields correctly.", "Car Part Registering Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Assignment.Models.CarPart newCarPart = new Assignment.Models.CarPart
                {
                    Name = name,
                    Description = description,
                    Price = price,
                    StockQuantity = stockQuantity
                };

                var result = DatabaseConnection.RegisterCarPart(newCarPart);

                if (result.Success)
                {
                    MessageBox.Show(result.Message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputFields()
        {
            carPartNameTextBox.Clear();
            descriptionTextBox.Clear();
            priceBox.Value = priceBox.Minimum;
            stockBox.Value = stockBox.Minimum;
        }
    }
}
