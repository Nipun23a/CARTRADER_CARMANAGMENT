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

namespace Assignment.Views.Search
{
    public partial class SearchView : Form
    {
        private Assignment.Models.IUser currentUser;
        public SearchView(Assignment.Models.IUser user)
        {
            InitializeComponent();
            currentUser = user; 
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            bool searchCars = radioCars.Checked;

            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Please enter a search term.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (searchCars)
            {
                SearchCars(searchTerm);
            }
            else
            {
                SearchCarParts(searchTerm);
            }
        }

        private void SearchCars(string searchTerm)
        {
            List<Assignment.Models.Car> results = new List<Assignment.Models.Car> ();
            string query = @"SELECT * FROM Cars 
                             WHERE Brand LIKE @SearchTerm 
                             OR Model LIKE @SearchTerm 
                             OR CAST(Year AS CHAR) LIKE @SearchTerm";
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                results.Add(new Assignment.Models.Car
                                {
                                    CarId = reader.GetInt32("CarId"),
                                    Brand = reader.GetString("Brand"),
                                    Model = reader.GetString("Model"),
                                    Year = reader.GetInt32("Year"),
                                    Price = reader.GetDouble("Price"),
                                    StockQuantity = reader.GetInt32("StockQuantity")
                                });
                            }
                        }
                    }
                }


                dgvResults.DataSource = results;
            } catch (Exception ex) 
            {
                MessageBox.Show($"Error searching cars: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchCarParts(string searchTerm)
        {
            List<Models.CarPart> results = new List<Models.CarPart> ();
            string query = @"SELECT * FROM CarParts 
                             WHERE Name LIKE @SearchTerm 
                             OR Description LIKE @SearchTerm";
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                results.Add(new Models.CarPart
                                {
                                    PartId = reader.GetInt32("PartId"),
                                    Name = reader.GetString("Name"),
                                    Description = reader.GetString("Description"),
                                    Price = reader.GetDouble("Price"),
                                    StockQuantity = reader.GetInt32("StockQuantity")
                                }
                                );
                            }
                        }
                    }
                }
                dgvResults.DataSource = results;
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Error searching car parts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void dgvResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvResults.Columns["btnOrder"].Index && e.RowIndex >= 0)
            {
                if (radioCars.Checked)
                {
                    Models.Car selectedCar = (Models.Car)dgvResults.Rows[e.RowIndex].DataBoundItem;
                    PlaceCarOrder(selectedCar);
                }
                else
                {
                    CarPart selectedPart = (CarPart)dgvResults.Rows[e.RowIndex].DataBoundItem;
                    PlacePartOrder(selectedPart);
                }
            }
        }

        private void PlaceCarOrder(Models.Car car)
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
                            // Insert into Orders table
                            string orderQuery = @"INSERT INTO Orders (UserId, OrderDate, TotalAmount, Status) 
                                         VALUES (@UserId, @OrderDate, @TotalAmount, @Status);
                                         SELECT LAST_INSERT_ID();";
                            int orderId;
                            using (MySqlCommand command = new MySqlCommand(orderQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@UserId", currentUser.UserID);
                                command.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                                command.Parameters.AddWithValue("@TotalAmount", car.Price);
                                command.Parameters.AddWithValue("@Status", OrderStatus.Pending.ToString());

                                orderId = Convert.ToInt32(command.ExecuteScalar());
                            }

                            // Insert into OrderItems table
                            string orderItemQuery = @"INSERT INTO OrderItems (OrderID, ItemType, ItemID, Quantity, Price)
                                              VALUES (@OrderID, @ItemType, @ItemID, @Quantity, @Price)";
                            using (MySqlCommand command = new MySqlCommand(orderItemQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@OrderID", orderId);
                                command.Parameters.AddWithValue("@ItemType", "Car");
                                command.Parameters.AddWithValue("@ItemID", car.CarId);
                                command.Parameters.AddWithValue("@Quantity", 1);
                                command.Parameters.AddWithValue("@Price", car.Price);

                                command.ExecuteNonQuery();
                            }

                            // Update stock quantity
                            string updateStockQuery = @"UPDATE Cars SET StockQuantity = StockQuantity - 1 
                                                WHERE CarId = @CarId AND StockQuantity > 0";
                            using (MySqlCommand command = new MySqlCommand(updateStockQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@CarId", car.CarId);
                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected == 0)
                                {
                                    throw new Exception("Car is out of stock.");
                                }
                            }

                            transaction.Commit();
                            MessageBox.Show($"Order placed for {car.Brand} {car.Model}. Order ID: {orderId}", "Order Placed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception($"Error placing order: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PlacePartOrder(CarPart part)
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
                            // Insert into Orders table
                            string orderQuery = @"INSERT INTO Orders (UserId, OrderDate, TotalAmount, Status) 
                                         VALUES (@UserId, @OrderDate, @TotalAmount, @Status);
                                         SELECT LAST_INSERT_ID();";
                            int orderId;
                            using (MySqlCommand command = new MySqlCommand(orderQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@UserId", currentUser.UserID);
                                command.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                                command.Parameters.AddWithValue("@TotalAmount", part.Price);
                                command.Parameters.AddWithValue("@Status", OrderStatus.Pending.ToString());

                                orderId = Convert.ToInt32(command.ExecuteScalar());
                            }

                            // Insert into OrderItems table
                            string orderItemQuery = @"INSERT INTO OrderItems (OrderID, ItemType, ItemID, Quantity, Price)
                                              VALUES (@OrderID, @ItemType, @ItemID, @Quantity, @Price)";
                            using (MySqlCommand command = new MySqlCommand(orderItemQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@OrderID", orderId);
                                command.Parameters.AddWithValue("@ItemType", "CarPart");
                                command.Parameters.AddWithValue("@ItemID", part.PartId);
                                command.Parameters.AddWithValue("@Quantity", 1);
                                command.Parameters.AddWithValue("@Price", part.Price);

                                command.ExecuteNonQuery();
                            }

                            // Update stock quantity
                            string updateStockQuery = @"UPDATE CarParts SET StockQuantity = StockQuantity - 1 
                                                WHERE PartId = @PartId AND StockQuantity > 0";
                            using (MySqlCommand command = new MySqlCommand(updateStockQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@PartId", part.PartId);
                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected == 0)
                                {
                                    throw new Exception("Part is out of stock.");
                                }
                            }

                            transaction.Commit();
                            MessageBox.Show($"Order placed for {part.Name}. Order ID: {orderId}", "Order Placed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception($"Error placing order: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


