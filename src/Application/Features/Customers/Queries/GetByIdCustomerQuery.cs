using Application.Features.Customers.Dtos;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Customers.Queries;
public class GetByIdCustomerQuery : IRequest<GetCustomerDto>
{
    public int Id { get; set; }
    public class GetByIdCustomerQueryHandler : IRequestHandler<GetByIdCustomerQuery, GetCustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetByIdCustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<GetCustomerDto> Handle(GetByIdCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetAsync(predicate: c => c.Id == request.Id);
            GetCustomerDto mappedCustomeryDto = _mapper.Map<GetCustomerDto>(customer);
            return mappedCustomeryDto;
        }
    }
}
