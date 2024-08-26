using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Assignment.Models;
using MySql.Data.MySqlClient;

namespace Assignment
{
    internal class DatabaseConnection
    {


        private static string connectionString = "Server=localhost;Database=car_traders;Uid=root;Pwd=1234;";

        public static (bool Success, string Message) TestConnection()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    return (true, "Database Connection Successfull");
                }
            }
            catch (MySqlException ex)
            {
                return (false, $"Database connection failed: {ex.Message}");
            }
        }

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }



        public static (bool Success, IUser User, string Message) Authenticateuser(string username, string password)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM users WHERE username = @username";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                User user = new User
                                {
                                    UserID = reader.GetInt32("UserID"),
                                    Username = reader.GetString("Username"),
                                    Password = reader.GetString("Password"),
                                    FirstName = reader.GetString("FirstName"),
                                    LastName = reader.GetString("LastName"),
                                    Email = reader.GetString("Email")
                                };
                                return (true, user, "Login Successfully");
                            }
                            else
                            {
                                return (false, null, "Invalid username or password");
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                return (false, null, $"Error Authenticating user:{ex.Message}");
            }
        }

        public static (bool Success, string Message) RegisterUser(IUser newUser)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();

                    // Check if username or email already exists
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username OR Email = @Email";
                    using (MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@Username", newUser.Username);
                        checkCommand.Parameters.AddWithValue("@Email", newUser.Email);

                        int userCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (userCount > 0)
                        {
                            return (false, "A user with the same username or email already exists.");
                        }
                    }

                    // Insert new user
                    string insertQuery = "INSERT INTO Users (Username, Password, FirstName, LastName, Email) VALUES (@Username, @Password, @FirstName, @LastName, @Email)";
                    using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@Username", newUser.Username);
                        insertCommand.Parameters.AddWithValue("@Password", newUser.Password);
                        insertCommand.Parameters.AddWithValue("@FirstName", newUser.FirstName);
                        insertCommand.Parameters.AddWithValue("@LastName", newUser.LastName);
                        insertCommand.Parameters.AddWithValue("@Email", newUser.Email);

                        int result = insertCommand.ExecuteNonQuery();

                        if (result > 0)
                        {
                            return (true, "User registered successfully.");
                        }
                        else
                        {
                            return (false, "User registration failed.");
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                return (false, $"An error occurred: {ex.Message}");
            }
        }

        public static (bool Success, string Message) RegisterCar(Car newCar)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO Cars (Brand, Model, Year, Price, StockQuantity) VALUES (@Brand, @Model, @Year, @Price, @StockQuantity)";
                    using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@Brand", newCar.Brand);
                        insertCommand.Parameters.AddWithValue("@Model", newCar.Model);
                        insertCommand.Parameters.AddWithValue("@Year", newCar.Year);
                        insertCommand.Parameters.AddWithValue("@Price", newCar.Price);
                        insertCommand.Parameters.AddWithValue("@StockQuantity", newCar.StockQuantity);
                        int result = insertCommand.ExecuteNonQuery();
                        if (result > 0)
                        {
                            return (true, "Car registered successfully.");
                        }
                        else
                        {
                            return (false, "Car registration failed.");
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                return (false, $"An error occurred: {ex.Message}");
            }
        }

        public static (bool Success, string Message) RegisterCarPart(CarPart newPart)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO CarParts (Name, Description, Price, StockQuantity) VALUES (@Name, @Description, @Price, @StockQuantity)";
                    using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@Name", newPart.Name);
                        insertCommand.Parameters.AddWithValue("@Description", newPart.Description);
                        insertCommand.Parameters.AddWithValue("@Price", newPart.Price);
                        insertCommand.Parameters.AddWithValue("@StockQuantity", newPart.StockQuantity);
                        int result = insertCommand.ExecuteNonQuery();
                        if (result > 0)
                        {
                            return (true, "Car part registered successfully.");
                        }
                        else
                        {
                            return (false, "Car part registration failed.");
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                return (false, $"An error occurred: {ex.Message}");
            }
        }


    }
}