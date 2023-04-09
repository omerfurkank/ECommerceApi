using Application.Features.Orders.Dtos;
using Application.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Orders.Queries;
public class GetByIdOrderQuery : IRequest<GetOrderDto>
{
    public int Id { get; set; }
    public class GetByIdOrderQueryHandler : IRequestHandler<GetByIdOrderQuery, GetOrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetByIdOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<GetOrderDto> Handle(GetByIdOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(predicate: p => p.Id == request.Id, include: p => p.Include(p => p.Customer));
            GetOrderDto mappedOrderDto = _mapper.Map<GetOrderDto>(order);
            return mappedOrderDto;
        }
    }
}
