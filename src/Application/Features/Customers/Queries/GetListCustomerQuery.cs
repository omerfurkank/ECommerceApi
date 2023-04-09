using Application.Features.Customers.Dtos;
using Application.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.Customers.Queries;

public class GetListCustomerQuery : IRequest<IList<GetCustomerDto>>
{
    public PageRequest PageRequest { get; set; }
    public class GetListCustomerQueryHandler : IRequestHandler<GetListCustomerQuery, IList<GetCustomerDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetListCustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<IList<GetCustomerDto>> Handle(GetListCustomerQuery request, CancellationToken cancellationToken)
        {
            var customers = _customerRepository.GetList().Skip(
                request.PageRequest.Page * request.PageRequest.PageSize).Take(request.PageRequest.PageSize);
            IList<GetCustomerDto> mappedCustomerListDto = _mapper.Map<IList<GetCustomerDto>>(customers);
            return mappedCustomerListDto;
        }
    }
}