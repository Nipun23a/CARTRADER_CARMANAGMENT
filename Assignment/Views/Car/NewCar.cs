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
    public partial class newCarPanel : Form
    {
        public newCarPanel()
        {
            InitializeComponent();

        }

        private void addCarButton_Click(object sender, EventArgs e)
        {
            string brand = brandTextBox.Text.Trim();
            string model = modelTextBox.Text.Trim();
            double price = Convert.ToDouble(priceBox.Value);
            int stockQuantiyt = Convert.ToInt32(stockQuality.Value);

            if (string.IsNullOrEmpty(brand) || string.IsNullOrEmpty(model) || (price <= 0.00) || (stockQuantiyt <= 0)) 
            {
                MessageBox.Show("Please fill in all fields.", "Car Registering Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Assignment.Models.Car newCar = new Assignment.Models.Car
                {
                    Brand = brand,
                    Model = model,
                    Year = DateTimePicker.Value.Year,
                    Price = price,
                    StockQuantity = stockQuantiyt,
                };

                var result = DatabaseConnection.RegisterCar(newCar);

                

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
            brandTextBox.Clear();
            modelTextBox.Clear();
            DateTimePicker.Value = DateTime.Now;
            priceBox.Value = priceBox.Minimum;
            stockQuality.Value = stockQuality.Minimum;
        }
    }
}
