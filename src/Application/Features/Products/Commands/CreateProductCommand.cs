using Application.Features.Products.Dtos;
using Application.Features.Products.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands;

public class CreateProductCommand : IRequest<CreatedProductDto>
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
    public int Price { get; set; }
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreatedProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ProductBusinessRules _businessRules;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper,ProductBusinessRules rules)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _businessRules = rules;
        }

        public async Task<CreatedProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
             await _businessRules.ProductNameCanNotBeDuplicatedWhenInserted(request.Name);

            Product mappedProduct = _mapper.Map<Product>(request);
            Product createdProduct = await _productRepository.AddAsync(mappedProduct);
            CreatedProductDto createdProductDto = _mapper.Map<CreatedProductDto>(createdProduct);
            return createdProductDto;
        }
    }
}
