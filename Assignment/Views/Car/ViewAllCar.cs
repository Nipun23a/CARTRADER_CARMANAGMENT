using MySql.Data.MySqlClient;
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
    public partial class ViewAllCar : Form
    {
        public ViewAllCar()
        {
            InitializeComponent();
            LoadCars();
        }

        private void LoadCars()
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Cars";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgvCars.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading cars: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvCars_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCars.Columns["btnAction"].Index && e.RowIndex >= 0)
            {
                int carId = Convert.ToInt32(dgvCars.Rows[e.RowIndex].Cells["CarID"].Value);
                string brand = dgvCars.Rows[e.RowIndex].Cells["Brand"].Value.ToString();
                string model = dgvCars.Rows[e.RowIndex].Cells["Model"].Value.ToString();

                var result = MessageBox.Show($"Choose an action for {brand} {model}:\nYes - Update\nNo - Delete\nCancel - Do nothing",
                                             "Action",
                                             MessageBoxButtons.YesNoCancel,
                                             MessageBoxIcon.Question);

                if (result == DialogResult.Yes) // Update
                {
                    UpdateCarForm updateForm = new UpdateCarForm(carId);
                    if (updateForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadCars(); // Refresh the grid after update
                    }
                }
                else if (result == DialogResult.No) // Delete
                {
                    if (MessageBox.Show($"Are you sure you want to delete {brand} {model}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        DeleteCar(carId);
                        LoadCars(); // Refresh the grid after delete
                    }
                }
            }
        }

        private void DeleteCar(int carId)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM Cars WHERE CarID = @CarID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CarID", carId);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Car deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete car.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting car: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}

