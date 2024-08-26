using System;
using System.Collections.Generic;

namespace Assignment.Models
{
    public class Order
    {
        public int OrderId { get; set; }
 

        // Add a User property to the Order class
        public IUser User { get; set; }

        // Use the FirstName property from the User class
        public int UserId => User?.UserID ?? 0;
        public string UserFirstName => User?.FirstName;

        public DateTime OrderDate { get; set; } = DateTime.Now;
        public double TotalAmount { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public List<OrderItem> OrderItems { get; set; }
    }

    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public string ItemType { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public enum OrderStatus
    {
        Pending,
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }
}
