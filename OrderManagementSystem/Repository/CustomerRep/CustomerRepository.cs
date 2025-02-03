using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Data;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Repository.CustomerRep
{
    public class CustomerRepository : ICustomerRepository, IDisposable
    {
        private readonly AppDbContext context;

        public CustomerRepository(AppDbContext context) {
            this.context = context;
        }


        public async Task<IEnumerable<Customer>> GetCustomersAsync() 
        {
            return await context.customers.ToListAsync();
        }
        public IQueryable<Customer> GetQueryableCustomers()
        {
            return context.customers ;
        }

        public async Task<Customer> GetCustomerByIdAsync(int id) 
        {
            return await context.customers.FindAsync(id);
        }

        public async Task InsertCustomerAsync(Customer customer)
        {
            await context.AddAsync(customer);
        }
        public async Task DeleteCustomerByIdAsync(int id)
        {
            Customer customer = await context.customers.FindAsync(id);
            if (customer != null) // Перевірка на null
            {
                context.customers.Remove(customer);
            }
        }
        public void UpdateCustomer(Customer customer) 
        {
            context.Entry(customer).State = EntityState.Modified;
        }
        public async Task SaveAsync() 
        {
            await context.SaveChangesAsync();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
