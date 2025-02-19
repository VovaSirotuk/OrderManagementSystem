﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.DTOs;
using OrderManagementSystem.DTOs.CustomerDTOs;
using OrderManagementSystem.Models;
using OrderManagementSystem.Repository.CustomerRep;
using OrderManagementSystem.Repository.OrderRep;

namespace OrderManagementSystem.Service.CustomerSer
{
    public class CustomerService : ICustomerService
    {
        private readonly IOrderRepository orderRepository;
        private readonly ICustomerRepository repository;
        private readonly IMapper mapper;

        public CustomerService(IOrderRepository orderRepository, ICustomerRepository repository, IMapper mapper) {

            this.orderRepository = orderRepository;
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDTO>> GetCustomersAsync() 
        {
            var customer =  await repository.GetCustomersAsync();
            return mapper.Map<List<CustomerDTO>>(customer);
             
        }
        public async Task<CustomerDTO> GetCustomerByIdAsync(int id) 
        {
            var customer =  await repository.GetCustomerByIdAsync(id);
            return mapper.Map<CustomerDTO>(customer);
        }

        public async Task<IEnumerable<CustomersOrderDTO>> GetCustomersOrdersAsync() 
        {
            var query = from c in repository.GetQueryableCustomers()
                        join o in orderRepository.GetQueryableOrders()
                        on c.Id equals o.CustomerId into customerOrders
                        select new CustomersOrderDTO
                        {
                            Id = c.Id,
                            Name = c.Name,
                            Email = c.Email,
                            Phone = c.Phone,
                            TotalOfOrder = customerOrders.Count()
                        };

            return await query.ToListAsync();
        }
        public async Task<CustomerDTO> InsertCustomerAsync(InsertCustomerDTO insertCustomerDTO)
        {
            var customer = mapper.Map<Customer>(insertCustomerDTO);
            await repository.InsertCustomerAsync(customer);
            await repository.SaveAsync();
            return mapper.Map<CustomerDTO>(customer);
        }
        public async Task DeleteCustomerByIdAsync(int id)
        {
            await repository.DeleteCustomerByIdAsync(id);
            await repository.SaveAsync();
        }
        public async Task UpdateCustomerAsync(CustomerDTO customerDTO) 
        {
            var customer = mapper.Map<Customer>(customerDTO);
            repository.UpdateCustomer(customer);
            await repository.SaveAsync();


        }
    }
}
