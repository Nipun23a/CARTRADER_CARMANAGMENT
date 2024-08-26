using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using PdfiumViewer;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = iTextSharp.text.Font;
using Assignment.Models;
using MySql.Data.MySqlClient;
using System.Configuration;
using Mysqlx.Crud;
using System.Text;
using System.Configuration;

namespace Assignment.Views.Reports
{
    public partial class OrderReportView : Form
    {
        private PdfViewer pdfViewer;

        public OrderReportView()
        {
            InitializeComponent();
            InitializePdfViewer();
        }

        private void InitializePdfViewer()
        {
            pdfViewer = new PdfViewer();
            pdfViewer.Dock = DockStyle.Fill;
            this.Controls.Add(pdfViewer);
        }

        private void generateReportButton_Click(object sender, EventArgs e)
        {
            GenerateOrderReport();
        }

        private void GenerateOrderReport()
        {
            // Set the date range (last 30 days)
            DateTime endDate = DateTime.Now;
            DateTime startDate = endDate.AddDays(-30);

            List<Assignment.Models.Order> orders = GetOrdersFromDatabase(startDate, endDate);

            // Generate the PDF report as a byte array
            byte[] pdfBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                using (Document document = new Document(PageSize.A4, 50, 50, 25, 25))
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, ms);
                    document.Open();

                    // Add content to the PDF
                    AddReportHeader(document, startDate, endDate, orders);
                    AddOrdersTable(document, orders);

                    document.Close();
                }
                pdfBytes = ms.ToArray();
            }

            // Load the PDF into the viewer
            if (pdfViewer.Document != null)
            {
                pdfViewer.Document.Dispose();
            }
            using (MemoryStream ms = new MemoryStream(pdfBytes))
            {
                pdfViewer.Document = PdfiumViewer.PdfDocument.Load(ms);
            }
        }

        // Sample method to generate a list of sample orders
        private List<Assignment.Models.Order> GetOrdersFromDatabase(DateTime startDate, DateTime endDate)
        {
            List<Assignment.Models.Order> orders = new List<Assignment.Models.Order>();


            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = @"SELECT o.OrderID, o.UserID, u.FirstName, o.OrderDate, o.TotalAmount, o.Status,
                         oi.OrderItemID, oi.ItemType, oi.ItemID, oi.Quantity, oi.Price
                         FROM Orders o
                         LEFT JOIN OrderItems oi ON o.OrderID = oi.OrderID
                         LEFT JOIN Users u ON o.UserID = u.UserID
                         WHERE o.OrderDate BETWEEN @StartDate AND @EndDate
                         ORDER BY o.OrderDate DESC";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Assignment.Models.Order order = new Assignment.Models.Order
                            {
                                OrderId = reader.GetInt32(0),
                                
                                User = new Assignment.Models.User
                                {
                                    UserID = reader.GetInt32(1),        
                                    FirstName = reader.GetString(2)     
                                },
                                OrderDate = reader.GetDateTime(3),
                                TotalAmount = reader.GetDouble(4),
                                Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), reader.GetString(5))
                            };

                            if (!reader.IsDBNull(6))
                            {
                                order.OrderItems = new List<OrderItem>
                        {
                            new OrderItem
                            {
                                OrderItemId = reader.GetInt32(6),
                                ItemType = reader.GetString(7),
                                ItemId = reader.GetInt32(8),
                                Quantity = reader.GetInt32(9),
                                Price = reader.GetDecimal(10)
                            }
                        };
                            }

                            orders.Add(order);
                        }
                    }
                }
            }

            return orders;
        }

        // Order class representing a single order
        private void AddReportHeader(Document document, DateTime startDate, DateTime endDate, List<Assignment.Models.Order> orders)
        {
            BaseFont helvetica = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font headerFont = new Font(helvetica, 18, 1);
            Font normalFont = new Font(helvetica, 12, 0);

            document.Add(new Paragraph("Order Report", headerFont));
            document.Add(new Paragraph($"Report generated on: {DateTime.Now:dd/MM/yyyy HH:mm}", normalFont));
            document.Add(new Paragraph($"Date range: {startDate:dd/MM/yyyy} - {endDate:dd/MM/yyyy}", normalFont));
            document.Add(new Paragraph($"Total orders: {orders.Count}", normalFont));
            document.Add(Chunk.NEWLINE);
        }
        private void AddOrdersTable(Document document, List<Assignment.Models.Order> orders)
        {
            PdfPTable table = new PdfPTable(6);
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 1f, 1f, 2f, 1.5f, 1.5f, 1.5f });

            AddTableHeader(table);

            foreach (var order in orders)
            {
                AddTableRow(table, order);
            }

            document.Add(table);
        }

        private void AddTableHeader(PdfPTable table)
        {
            BaseFont helvetica = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font headerFont = new Font(helvetica, 12, 1);

            string[] headers = { "Order ID", "User Name", "Order Date", "Total Amount", "Status", "Items" };
            foreach (string header in headers)
            {
                PdfPCell cell = new PdfPCell(new Phrase(header, headerFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                table.AddCell(cell);
            }
        }

        private void AddTableRow(PdfPTable table, Assignment.Models.Order order)
        {
            table.AddCell(order.OrderId.ToString());
            table.AddCell(order.UserFirstName);
            table.AddCell(order.OrderDate.ToString("dd/MM/yyyy HH:mm"));
            table.AddCell(order.TotalAmount.ToString("C"));
            table.AddCell(order.Status.ToString());

            if (order.OrderItems != null && order.OrderItems.Count > 0)
            {
                StringBuilder itemsBuilder = new StringBuilder();
                foreach (var item in order.OrderItems)
                {
                    itemsBuilder.AppendLine($"{item.ItemType} (ID: {item.ItemId})");
                    itemsBuilder.AppendLine($"Qty: {item.Quantity}, Price: {item.Price:C}");
                    itemsBuilder.AppendLine();
                }
                table.AddCell(itemsBuilder.ToString());
            }
            else
            {
                table.AddCell("No items");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }

                if (pdfViewer != null)
                {
                    if (pdfViewer.Document != null)
                    {
                        pdfViewer.Document.Dispose();
                    }
                    pdfViewer.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}