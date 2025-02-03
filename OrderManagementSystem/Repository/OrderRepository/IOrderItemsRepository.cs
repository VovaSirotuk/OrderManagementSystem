using OrderManagementSystem.Models;

namespace OrderManagementSystem.Repository.OrderItemRepository
{
    public interface IOrderItemsRepository
    {
        Task<IEnumerable<OrderItem>> GetOrderItemAsync();
        Task<OrderItem> GetOrderItemByIdAsync(int id);
        IQueryable<OrderItem> GetQueryableOrderItems();
        Task InsertOrderItemsAsync(OrderItem orderItem);
        Task DeleteOrderItemByIdAsync(int id);
        void UpdateOrderItem(OrderItem orderItem);
        Task SaveAsync();
    }
}
