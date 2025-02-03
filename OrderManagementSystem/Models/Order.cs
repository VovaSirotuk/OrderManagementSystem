﻿namespace OrderManagementSystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public Customer customer { get; set; } // = null!;
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();



    }
}
