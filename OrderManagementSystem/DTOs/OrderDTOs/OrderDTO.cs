﻿using OrderManagementSystem.Models;

namespace OrderManagementSystem.DTOs.OrderDTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
