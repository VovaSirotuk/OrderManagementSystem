using AutoMapper;
using OrderManagementSystem.DTOs.CustomerDTOs;
using OrderManagementSystem.DTOs.OrderDTOs;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Customer, InsertCustomerDTO>().ReverseMap();
            CreateMap<Customer, CustomersOrderDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Order, InsertOrderDTO>().ReverseMap();
        }
    }
}
