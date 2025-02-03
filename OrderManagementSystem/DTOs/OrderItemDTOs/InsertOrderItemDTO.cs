namespace OrderManagementSystem.DTOs.OrderItemDTOs
{
    public class InsertOrderItemDTO
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
        public decimal Total { get; private set; }
    }
}
