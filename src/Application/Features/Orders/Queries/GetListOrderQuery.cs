using Application.Features.Orders.Dtos;
using Application.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Orders.Queries;

public class GetListOrderQuery : IRequest<IList<GetOrderDto>>
{
    public PageRequest PageRequest { get; set; }
    public class GetListProductQueryHandler : IRequestHandler<GetListOrderQuery, IList<GetOrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetListProductQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IList<GetOrderDto>> Handle(GetListOrderQuery request, CancellationToken cancellationToken)
        {
            var orders = _orderRepository.GetList(include: p => p.Include(p => p.Customer)).Skip(
                request.PageRequest.Page * request.PageRequest.PageSize).Take(request.PageRequest.PageSize);
            IList<GetOrderDto> mappedOrderListDto = _mapper.Map<IList<GetOrderDto>>(orders);
            return mappedOrderListDto;
        }
    }
}
