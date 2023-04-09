using Application.Features.Orders.Dtos;
using Application.Features.Orders.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Orders.Commands;
public class CreateOrderCommand : IRequest<CreatedOrderDto>
{
    public int CustomerId { get; set; }
    public string Description { get; set; }
    public string Adress { get; set; }
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreatedOrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly OrderBusinessRules _businessRules;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, OrderBusinessRules rules)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _businessRules = rules;
        }

        public async Task<CreatedOrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {

            Order mappedOrder = _mapper.Map<Order>(request);
            Order createdOrder = await _orderRepository.AddAsync(mappedOrder);
            CreatedOrderDto createdOrderDto = _mapper.Map<CreatedOrderDto>(createdOrder);
            return createdOrderDto;
        }
    }
}
