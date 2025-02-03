using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Data;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Repository.OrderItemRepository
{
    public class OrderItemRepository : IOrderItemsRepository
    {
        private readonly AppDbContext context;

        public OrderItemRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItemAsync() {

            return await context.orderItems.ToListAsync();
        }
        public async Task<OrderItem> GetOrderItemByIdAsync(int id) {
            return await context.orderItems.FindAsync(id);
        }
        public IQueryable<OrderItem> GetQueryableOrderItems() 
        {
            return context.orderItems;
        }
        public async Task InsertOrderItemsAsync(OrderItem orderItem) 
        {
            await context.orderItems.AddAsync(orderItem);
        }
        public async Task DeleteOrderItemByIdAsync(int id) {

            var orderItem = await context.orderItems.FindAsync(id);
            if (orderItem != null) {
                context.orderItems.Remove(orderItem);
            }
        }
        public void UpdateOrderItem(OrderItem orderItem) { }
        public async Task SaveAsync() {
            await context.SaveChangesAsync();
        }
    }
}
