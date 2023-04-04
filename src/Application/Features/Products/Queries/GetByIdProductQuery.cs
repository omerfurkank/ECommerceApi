using Application.Features.Products.Dtos;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Products.Queries;

public class GetByIdProductQuery : IRequest<GetProductDto>
{
    public int Id { get; set; }
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, GetProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetByIdProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetProductDto> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAsync(p => p.Id == request.Id);
            GetProductDto mappedProductDto = _mapper.Map<GetProductDto>(product);
            return mappedProductDto;
        }
    }
}