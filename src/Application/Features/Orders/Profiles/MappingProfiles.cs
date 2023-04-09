using Application.Features.Orders.Commands;
using Application.Features.Orders.Dtos;
using Application.Features.Products.Commands;
using Application.Features.Products.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Order, CreateOrderCommand>().ReverseMap();
        CreateMap<Order, CreatedOrderDto>().ReverseMap();
        CreateMap<Order, UpdateOrderCommand>().ReverseMap();
        CreateMap<Order, UpdatedOrderDto>().ReverseMap();
        CreateMap<Order, DeleteOrderCommand>().ReverseMap();
        CreateMap<Order, DeletedOrderDto>().ReverseMap();

        CreateMap<Order, GetOrderDto>().ForMember(p => p.CustomerName, opt => opt.MapFrom(p => p.Customer.Name));
    }
}
