using System.ComponentModel.DataAnnotations;
namespace OrderManagementSystem.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
        public decimal Total { get; private set; }

        public Order order { get; set; } // = null!;

    }
}
