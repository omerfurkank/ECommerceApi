using Application.Features.Products.Dtos;
using Application.Features.Products.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands;

public class UpdateProductCommand : IRequest<UpdatedProductDto>
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
    public int Price { get; set; }
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdatedProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ProductBusinessRules _businessRules;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper, ProductBusinessRules rules)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _businessRules = rules;
        }

        public async Task<UpdatedProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product mappedProduct = _mapper.Map<Product>(request);
            Product updatedProduct = await _productRepository.UpdateAsync(mappedProduct);
            UpdatedProductDto updatedProductDto = _mapper.Map<UpdatedProductDto>(updatedProduct);
            return updatedProductDto;
        }
    }
}