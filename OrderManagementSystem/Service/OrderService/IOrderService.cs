using OrderManagementSystem.DTOs.OrderDTOs;

namespace OrderManagementSystem.Service.OrderService
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetOrdersAsync();
        Task<OrderDTO> GetOrderByIdAsync(int id);

        Task<OrderDTO> InsertOrderAsync(InsertOrderDTO insertorderDTO);
        Task DeleteOrderByIdAsync(int id);
        Task UpdateOrderAsync(OrderDTO orderDTO);
    }
}
 