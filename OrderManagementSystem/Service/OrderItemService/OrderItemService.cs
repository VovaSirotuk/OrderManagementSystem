using AutoMapper;
using OrderManagementSystem.DTOs.CustomerDTOs;
using OrderManagementSystem.DTOs.OrderItemDTOs;
using OrderManagementSystem.Models;
using OrderManagementSystem.Repository.OrderItemRepository;

namespace OrderManagementSystem.Service.OrderItemService
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemsRepository repository;
        private readonly IMapper mapper;

        public OrderItemService(IOrderItemsRepository repository, IMapper mapper) 
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<OrderItemDTO>> GetOrderItemsAsync() 
        {
            var orderItems = await repository.GetOrderItemAsync();
            return mapper.Map<List<OrderItemDTO>>(orderItems);
        }
        public async Task<OrderItemDTO> GetOrderItemByIdAsync(int id) 
        {
            var orderItem = await repository.GetOrderItemByIdAsync(id);
            return mapper.Map<OrderItemDTO>(orderItem);
        }

        public async Task<OrderItemDTO> InsertOrderItemAsync(InsertOrderItemDTO insertOrderItemDTO) 
        {
            var insertOrderItem = mapper.Map<OrderItem>(insertOrderItemDTO);
            await repository.InsertOrderItemsAsync(insertOrderItem);
            await repository.SaveAsync();
            return mapper.Map<OrderItemDTO>(insertOrderItem);
        }
        public async Task DeleteOrderItemByIdAsync(int id) 
        {
            var orderItem = repository.DeleteOrderItemByIdAsync(id);
            await repository.SaveAsync();
        }
        public async Task UpdateOrderItemAsync(OrderItemDTO orderItemDTO) 
        {
            var updateOrderItem = mapper.Map<OrderItem>(orderItemDTO);
            repository.UpdateOrderItem(updateOrderItem);
            await repository.SaveAsync();
        }
    }
}
