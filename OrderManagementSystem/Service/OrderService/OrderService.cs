using AutoMapper;
using OrderManagementSystem.DTOs;
using OrderManagementSystem.DTOs.CustomerDTOs;
using OrderManagementSystem.DTOs.OrderDTOs;
using OrderManagementSystem.Models;
using OrderManagementSystem.Repository.CustomerRep;
using OrderManagementSystem.Repository.OrderRep;

namespace OrderManagementSystem.Service.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository repository;
        private readonly IMapper mapper;

        public OrderService(IOrderRepository repository, IMapper mapper) {
            
            this.repository = repository;
            this.mapper = mapper;
        }


        public async Task<IEnumerable<OrderDTO>> GetOrdersAsync() 
        {
            var customer =  await repository.GetOrdersAsync();
            return mapper.Map<List<OrderDTO>>(customer);
             
        }
        public async Task<OrderDTO> GetOrderByIdAsync(int id) 
        {
            var customer =  await repository.GetOrderByIdAsync(id);
            return mapper.Map<OrderDTO>(customer);
        }

        public async Task<OrderDTO> InsertOrderAsync(InsertOrderDTO insertOrderDTO)
        {
            var order = mapper.Map<Order>(insertOrderDTO);
            await repository.InsertOrderAsync(order);
            await repository.SaveAsync();
            return mapper.Map<OrderDTO>(order);
        }
        public async Task DeleteOrderByIdAsync(int id)
        {
            await repository.DeleteOrderByIdAsync(id);
            await repository.SaveAsync();
        }
        public async Task UpdateOrderAsync(OrderDTO orderDTO) 
        {
            var order = mapper.Map<Order>(orderDTO);
            repository.UpdateOrder(order);
            await repository.SaveAsync();


        }
    }
}
