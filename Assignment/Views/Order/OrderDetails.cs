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
    public partial class OrderDetails : Form
    {
        private bool isLoading = true;
        public OrderDetails()
        {
            InitializeComponent();
            LoadOrders();
            isLoading = false;
        }

        private void LoadOrders()
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"
                SELECT o.OrderID, u.FirstName, u.LastName, o.OrderDate, o.TotalAmount, o.Status,
                    CASE 
                        WHEN oi.ItemType = 'Car' THEN c.Brand 
                        ELSE cp.Name 
                    END AS ItemName
                FROM Orders o
                JOIN Users u ON o.UserID = u.UserID
                JOIN OrderItems oi ON o.OrderID = oi.OrderID
                LEFT JOIN Cars c ON oi.ItemID = c.CarId AND oi.ItemType = 'Car'
                LEFT JOIN CarParts cp ON oi.ItemID = cp.PartId AND oi.ItemType = 'CarPart'
                ORDER BY o.OrderDate DESC";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            dgvOrders.DataSource = null;
                            dgvOrders.Columns.Clear();
                            dgvOrders.DataSource = dataTable;

                            // Add a combo box column for status update if it doesn't exist
                            if (!dgvOrders.Columns.Contains("UpdateStatus"))
                            {
                                DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn();
                                statusColumn.Name = "UpdateStatus";
                                statusColumn.HeaderText = "Update Status";
                                statusColumn.DataSource = new string[] { "Pending", "Processing", "Shipped", "Delivered", "Cancelled" };
                                dgvOrders.Columns.Add(statusColumn);
                            }

                            // Update the Status combo box based on current order status
                            foreach (DataGridViewRow row in dgvOrders.Rows)
                            {
                                string status = row.Cells["Status"].Value.ToString();
                                row.Cells["UpdateStatus"].Value = status;

                                if (status == "Shipped" || status == "Delivered" || status == "Cancelled")
                                {
                                    row.Cells["UpdateStatus"].ReadOnly = true;
                                }
                            }

                            // Refresh the DataGridView to apply changes without triggering CellValueChanged
                            dgvOrders.Refresh();
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
    if (e.ColumnIndex == dgvOrders.Columns["UpdateStatus"].Index && e.RowIndex >= 0)
    {
        DataGridViewRow row = dgvOrders.Rows[e.RowIndex];
        string currentStatus = row.Cells["Status"].Value.ToString();
        string newStatus = row.Cells["UpdateStatus"].Value.ToString();
        int orderId = Convert.ToInt32(row.Cells["OrderID"].Value);

        if (newStatus == "Cancelled" && currentStatus != "Cancelled")
        {
            DialogResult result = MessageBox.Show("Are you sure you want to cancel this order?", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                UpdateOrderStatus(orderId, "Cancelled");
            }
            else
            {
                // Reset the combo box to the current status if cancellation is not confirmed
                row.Cells["UpdateStatus"].Value = currentStatus;
            }
        }
        else if (currentStatus == "Shipped" || currentStatus == "Delivered" || currentStatus == "Cancelled")
        {
            MessageBox.Show("This order cannot be modified as it has already been shipped, delivered or cancelled.", "Cannot Modify", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Reset the combo box to the current status
            row.Cells["UpdateStatus"].Value = currentStatus;
        }
        else if (currentStatus != newStatus)
        {
            UpdateOrderStatus(orderId, newStatus);
        }
    }
}

        private void dgvOrders_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isLoading) return;

            if (e.ColumnIndex == dgvOrders.Columns["UpdateStatus"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvOrders.Rows[e.RowIndex];
                int orderId = Convert.ToInt32(row.Cells["OrderID"].Value);
                string currentStatus = row.Cells["Status"].Value.ToString();
                string newStatus = row.Cells["UpdateStatus"].Value.ToString();

                if (currentStatus != newStatus)
                {
                    UpdateOrderStatus(orderId, newStatus);
                }
            }
        }

        private void UpdateOrderStatus(int orderId, string newStatus)
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
                            string updateQuery = "UPDATE Orders SET Status = @Status WHERE OrderID = @OrderID";
                            using (MySqlCommand command = new MySqlCommand(updateQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@Status", newStatus);
                                command.Parameters.AddWithValue("@OrderID", orderId);
                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    if (newStatus == "Cancelled")
                                    {
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

                                        using (MySqlCommand restoreCommand = new MySqlCommand(restoreStockQuery, connection, transaction))
                                        {
                                            restoreCommand.Parameters.AddWithValue("@OrderID", orderId);
                                            restoreCommand.ExecuteNonQuery();
                                        }
                                    }

                                    transaction.Commit();

                                    // Update the DataGridView
                                    DataGridViewRow row = dgvOrders.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => Convert.ToInt32(r.Cells["OrderID"].Value) == orderId);
                                    if (row != null)
                                    {
                                        row.Cells["Status"].Value = newStatus;
                                        if (newStatus == "Shipped" || newStatus == "Delivered" || newStatus == "Cancelled")
                                        {
                                            row.Cells["UpdateStatus"].ReadOnly = true;
                                        }
                                    }
                                    MessageBox.Show("Order status updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    throw new Exception("Unable to update order status.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception($"Error updating order status: {ex.Message}");
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

