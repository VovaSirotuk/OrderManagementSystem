using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Data;
using OrderManagementSystem.Migrations;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Repository.OrderRep
{
    public class OrderRepository : IOrderRepository
    {   
        private readonly AppDbContext context;

        public OrderRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Order>> GetOrdersAsync() {

            return await context.orders.ToListAsync();
        }
        public async Task<IQueryable<Order>> GetQueryableOrdersAsync()
        {

            return context.orders ;
        }
        public async Task<Order> GetOrderByIdAsync(int id) 
        {
            return await context.orders.FindAsync(id);
        }

        public async Task InsertOrderAsync(Order order) 
        {
            await context.AddAsync(order);
        }
        public async Task DeleteOrderByIdAsync(int id) 
        {
            var order = await context.orders.FindAsync(id);
            if (order != null)
            {
                context.orders.Remove(order);
            }
        }
        public void UpdateOrder(Order order) 
        {
            context.Entry(order).State = EntityState.Modified;
        }
        public async Task SaveAsync() 
        {
            await context.SaveChangesAsync();
        }
    }
}
