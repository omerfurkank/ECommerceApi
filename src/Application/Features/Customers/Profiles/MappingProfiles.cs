using Application.Features.Customers.Commands;
using Application.Features.Customers.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Customers.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
        CreateMap<Customer, CreatedCustomerDto>().ReverseMap();
        CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
        CreateMap<Customer, UpdatedCustomerDto>().ReverseMap();
        CreateMap<Customer, DeleteCustomerCommand>().ReverseMap();
        CreateMap<Customer, DeletedCustomerDto>().ReverseMap();

        CreateMap<GetCustomerDto, Customer>().ReverseMap();
    }
}