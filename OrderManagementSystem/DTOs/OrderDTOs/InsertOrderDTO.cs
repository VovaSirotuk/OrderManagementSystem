﻿namespace OrderManagementSystem.DTOs.OrderDTOs
{
    public class InsertOrderDTO
    {
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
