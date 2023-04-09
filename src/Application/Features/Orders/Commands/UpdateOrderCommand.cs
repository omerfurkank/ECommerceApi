using Application.Features.Orders.Dtos;
using Application.Features.Orders.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Orders.Commands;

public class UpdateOrderCommand : IRequest<UpdatedOrderDto>
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string Description { get; set; }
    public string Adress { get; set; }
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, UpdatedOrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly OrderBusinessRules _businessRules;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, OrderBusinessRules rules)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _businessRules = rules;
        }

        public async Task<UpdatedOrderDto> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {

            Order mappedOrder = _mapper.Map<Order>(request);
            Order updatedOrder = await _orderRepository.UpdateAsync(mappedOrder);
            UpdatedOrderDto updatedOrderDto = _mapper.Map<UpdatedOrderDto>(updatedOrder);
            return updatedOrderDto;
        }
    }
}