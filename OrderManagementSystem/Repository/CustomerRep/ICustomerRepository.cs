using OrderManagementSystem.Models;
namespace OrderManagementSystem.Repository.CustomerRep
{
    public interface ICustomerRepository : IDisposable
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<IQueryable<Customer>> GetQueryableCustomersAsync();
        Task InsertCustomerAsync(Customer customer);
        Task DeleteCustomerByIdAsync(int id);
        void UpdateCustomer(Customer customer);
        Task SaveAsync();
    }
}
 