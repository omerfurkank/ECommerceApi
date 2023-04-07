using Application.Features.Categories.Commands;
using Application.Features.Categories.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Category, CreateCategoryCommand>().ReverseMap();
        CreateMap<Category, CreatedCategoryDto>().ReverseMap();

        CreateMap<GetCategoryDto, Category>().ReverseMap();
    }
}
