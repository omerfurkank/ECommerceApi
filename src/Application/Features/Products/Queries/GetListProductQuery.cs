﻿using Application.Features.Products.Dtos;
using Application.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries;

public class GetListProductQuery : IRequest<IList<GetProductDto>>
{
    public PageRequest PageRequest { get; set; }
    public class GetListProductQueryHandler : IRequestHandler<GetListProductQuery, IList<GetProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetListProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IList<GetProductDto>> Handle(GetListProductQuery request, CancellationToken cancellationToken)
        {
            var products = _productRepository.GetList().Skip(
                request.PageRequest.Page * request.PageRequest.PageSize).Take(request.PageRequest.PageSize);
            IList<GetProductDto> mappedProductListDto = _mapper.Map<IList<GetProductDto>>(products);
            return mappedProductListDto;
        }
    }
}
