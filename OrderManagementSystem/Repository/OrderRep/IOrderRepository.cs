﻿using OrderManagementSystem.Models;

namespace OrderManagementSystem.Repository.OrderRep
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        IQueryable<Order> GetQueryableOrders();
        Task InsertOrderAsync(Order order);
        Task DeleteOrderByIdAsync(int id);
        void UpdateOrder(Order order);
        Task SaveAsync();
    }
}
