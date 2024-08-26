using Assignment.Views.Car;
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

namespace Assignment.Views.Car_Part
{
    public partial class ViewAllParts : Form
    {
        public ViewAllParts()
        {
            InitializeComponent();
            LoadCarParts();
        }


        private void LoadCarParts()
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM CarParts ";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgvParts.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading cars: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvParts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvParts.Columns["btnAction"].Index && e.RowIndex >= 0)
            {
                int PartId = Convert.ToInt32(dgvParts.Rows[e.RowIndex].Cells["PartID"].Value);
                string name = dgvParts.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                string descriptioj = dgvParts.Rows[e.RowIndex].Cells["Description"].Value.ToString();

                var result = MessageBox.Show($"Choose an action for {name}:\nYes - Update\nNo - Delete\nCancel - Do nothing",
                                             "Action",
                                             MessageBoxButtons.YesNoCancel,
                                             MessageBoxIcon.Question);

                if (result == DialogResult.Yes) // Update
                {
                    UpdatePartForm updateForm = new UpdatePartForm(PartId);
                    if (updateForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadCarParts(); // Refresh the grid after update
                    }
                }
                else if (result == DialogResult.No) // Delete
                {
                    if (MessageBox.Show($"Are you sure you want to delete {name} ?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        DeleteCarPart(PartId);
                        LoadCarParts(); // Refresh the grid after delete
                    }
                }
            }
        }

        private void DeleteCarPart(int partId)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM CarParts WHERE PartID = @PartID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PartID", partId);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Car Part deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete car part.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting car part: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
