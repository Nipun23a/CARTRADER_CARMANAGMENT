using Assignment.Models;
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

namespace Assignment.Views.Order
{
    public partial class CustomerOrderDetails : Form
    {

        private readonly IUser currentUser;
        public CustomerOrderDetails(IUser user)
        {
            InitializeComponent();
            currentUser = user;
            LoadOrders();
        }

        private void LoadOrders()
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT o.OrderID, o.OrderDate, o.TotalAmount, o.Status, 
                            CASE 
                                WHEN oi.ItemType = 'Car' THEN c.Brand 
                                ELSE cp.Name 
                            END AS ItemName
                            FROM Orders o
                            JOIN OrderItems oi ON o.OrderID = oi.OrderID
                            LEFT JOIN Cars c ON oi.ItemID = c.CarId AND oi.ItemType = 'Car'
                            LEFT JOIN CarParts cp ON oi.ItemID = cp.PartId AND oi.ItemType = 'CarPart'
                            WHERE o.UserID = @UserID
                            ORDER BY o.OrderDate DESC";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", currentUser.UserID);
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            dgvOrders.DataSource = null; // Clear the existing data source
                            dgvOrders.Columns.Clear();   // Clear all columns
                            dgvOrders.DataSource = dataTable;

                            // Add a button column for cancellation if it doesn't exist
                            if (!dgvOrders.Columns.Contains("Cancel"))
                            {
                                DataGridViewButtonColumn cancelButtonColumn = new DataGridViewButtonColumn();
                                cancelButtonColumn.Name = "Cancel";
                                cancelButtonColumn.HeaderText = "Cancel Order";
                                cancelButtonColumn.Text = "Cancel";
                                cancelButtonColumn.UseColumnTextForButtonValue = true;
                                dgvOrders.Columns.Add(cancelButtonColumn);
                            }

                            // Update the Cancel button visibility based on order status
                            foreach (DataGridViewRow row in dgvOrders.Rows)
                            {
                                string status = row.Cells["Status"].Value.ToString();
                                if (status == "Shipped" || status == "Delivered" || status == "Cancelled")
                                {
                                    row.Cells["Cancel"].Value = "N/A";
                                    row.Cells["Cancel"].Style.BackColor = System.Drawing.Color.LightGray;
                                }
                                else
                                {
                                    row.Cells["Cancel"].Value = "Cancel";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvOrders.Columns["Cancel"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvOrders.Rows[e.RowIndex];
                string status = row.Cells["Status"].Value.ToString();
                int orderId = Convert.ToInt32(row.Cells["OrderID"].Value);

                if (status != "Shipped" && status != "Delivered")
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to cancel this order?", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        CancelOrder(orderId);
                    }
                }
                else
                {
                    MessageBox.Show("This order cannot be cancelled as it has already been shipped,delivered or cancelled.", "Cannot Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void CancelOrder(int orderId)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    using (MySqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Update order status
                            string updateOrderQuery = "UPDATE Orders SET Status = 'Cancelled' WHERE OrderID = @OrderID AND Status IN ('Pending', 'Processing')";
                            using (MySqlCommand command = new MySqlCommand(updateOrderQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@OrderID", orderId);
                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected == 0)
                                {
                                    throw new Exception("Unable to cancel the order. It may have already been shipped or delivered.");
                                }
                            }

                            // Restore stock quantity
                            string restoreStockQuery = @"
                        UPDATE Cars c
                        JOIN OrderItems oi ON c.CarId = oi.ItemID
                        SET c.StockQuantity = c.StockQuantity + oi.Quantity
                        WHERE oi.OrderID = @OrderID AND oi.ItemType = 'Car';

                        UPDATE CarParts cp
                        JOIN OrderItems oi ON cp.PartId = oi.ItemID
                        SET cp.StockQuantity = cp.StockQuantity + oi.Quantity
                        WHERE oi.OrderID = @OrderID AND oi.ItemType = 'CarPart';";

                            using (MySqlCommand command = new MySqlCommand(restoreStockQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@OrderID", orderId);
                                command.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("Order cancelled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadOrders(); // Refresh the grid
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception($"Error cancelling order: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }
    }
}
