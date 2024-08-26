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

namespace Assignment.Views.User
{
    public partial class UserDetails : Form
    {
        public UserDetails()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Users";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgvUsers.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading cars: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvUsers.Columns["btnAction"].Index && e.RowIndex >= 0)
            {
                int userId = Convert.ToInt32(dgvUsers.Rows[e.RowIndex].Cells["UserID"].Value);
                string username = dgvUsers.Rows[e.RowIndex].Cells["Username"].Value.ToString();
                string firstname = dgvUsers.Rows[e.RowIndex].Cells["FirstName"].Value.ToString();
                string lastname = dgvUsers.Rows[e.RowIndex].Cells["LasrtName"].Value.ToString();
            }
        }
    }
}
