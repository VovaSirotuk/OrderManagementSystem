using OrderManagementSystem.DTOs.OrderDTOs;
using OrderManagementSystem.DTOs.OrderItemDTOs;

namespace OrderManagementSystem.Service.OrderItemService
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItemDTO>> GetOrderItemsAsync();
        Task<OrderItemDTO> GetOrderItemByIdAsync(int id);

        Task<OrderItemDTO> InsertOrderItemAsync(InsertOrderItemDTO insertOrderItemDTO);
        Task DeleteOrderItemByIdAsync(int id);
        Task UpdateOrderItemAsync(OrderItemDTO orderDTO);
    }
}
