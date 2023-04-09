using Application.Features.Orders.Dtos;
using Application.Features.Orders.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Orders.Commands;

public class DeleteOrderCommand : IRequest<DeletedOrderDto>
{
    public int Id { get; set; }
    public class CreateOrderCommandHandler : IRequestHandler<DeleteOrderCommand, DeletedOrderDto>
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

        public async Task<DeletedOrderDto> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {

            Order mappedOrder = _mapper.Map<Order>(request);
            Order deletedOrder = await _orderRepository.DeleteAsync(mappedOrder);
            DeletedOrderDto deletedOrderDto = _mapper.Map<DeletedOrderDto>(deletedOrder);
            return deletedOrderDto;
        }
    }
}
