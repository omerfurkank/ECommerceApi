using Application.Features.Categories.Dtos;
using Application.Features.Products.Dtos;
using Application.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Queries;

public class GetListCategoryQuery : IRequest<IList<GetCategoryDto>>
{
    public PageRequest PageRequest { get; set; }
    public class GetListCategoryQueryHandler : IRequestHandler<GetListCategoryQuery, IList<GetCategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetListCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IList<GetCategoryDto>> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
        {
            var products = _categoryRepository.GetList().Skip(
                request.PageRequest.Page * request.PageRequest.PageSize).Take(request.PageRequest.PageSize);
            IList<GetCategoryDto> mappedCategoryListDto = _mapper.Map<IList<GetCategoryDto>>(products);
            return mappedCategoryListDto;
        }
    }
}