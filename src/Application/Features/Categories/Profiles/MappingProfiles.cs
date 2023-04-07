using Application.Features.Categories.Commands;
using Application.Features.Categories.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Categories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Category, CreateCategoryCommand>().ReverseMap();
        CreateMap<Category, CreatedCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
        CreateMap<Category, UpdatedCategoryDto>().ReverseMap();
        CreateMap<Category, DeleteCategoryCommand>().ReverseMap();
        CreateMap<Category, DeletedCategoryDto>().ReverseMap();

        CreateMap<GetCategoryDto, Category>().ReverseMap();
    }
}
