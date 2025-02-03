using OrderManagementSystem.DTOs.CustomerDTOs;

namespace OrderManagementSystem.Service.CustomerSer
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDTO>> GetCustomersAsync();
        Task<CustomerDTO> GetCustomerByIdAsync(int id);
        Task<IEnumerable<CustomersOrderDTO>> GetCustomersOrdersAsync();
        Task<CustomerDTO> InsertCustomerAsync(InsertCustomerDTO customerDTO);
        Task DeleteCustomerByIdAsync(int id);
        Task UpdateCustomerAsync(CustomerDTO customerDTO);
    }
}
 