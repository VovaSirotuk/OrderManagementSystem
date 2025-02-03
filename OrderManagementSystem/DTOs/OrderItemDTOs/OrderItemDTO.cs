using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.DTOs.OrderItemDTOs
{
    public class OrderItemDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
        public decimal Total { get; private set; }
    }
}
