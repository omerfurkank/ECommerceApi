using Application.Features.Customers.Dtos;
using Application.Features.Customers.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customers.Commands;

public class UpdateCustomerCommand : IRequest<UpdatedCustomerDto>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, UpdatedCustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly CustomerBusinessRules _businessRules;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, CustomerBusinessRules rules)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _businessRules = rules;
        }

        public async Task<UpdatedCustomerDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer mappedCustomer = _mapper.Map<Customer>(request);
            Customer updatedCustomer = await _customerRepository.UpdateAsync(mappedCustomer);
            UpdatedCustomerDto uptatedCustomerDto = _mapper.Map<UpdatedCustomerDto>(updatedCustomer);
            return uptatedCustomerDto;
        }
    }
}