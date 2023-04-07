using Application.Features.Products.Commands;
using Application.Features.Products.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Products.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, CreateProductCommand>().ReverseMap();
        CreateMap<Product, CreatedProductDto>().ReverseMap();
        CreateMap<Product, UpdateProductCommand>().ReverseMap();
        CreateMap<Product, UpdatedProductDto>().ReverseMap();
        CreateMap<Product, DeleteProductCommand>().ReverseMap();
        CreateMap<Product, DeletedProductDto>().ReverseMap();

        CreateMap<Product, GetProductDto>().ForMember(p => p.CategoryName, opt => opt.MapFrom(p => p.Category.Name));
    }
}