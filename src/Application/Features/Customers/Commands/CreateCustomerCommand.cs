﻿using Application.Features.Customers.Dtos;
using Application.Features.Customers.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customers.Commands;
public class CreateCustomerCommand : IRequest<CreatedCustomerDto>
{
    public string Name { get; set; }
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreatedCustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly CustomerBusinessRules _businessRules;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, CustomerBusinessRules rules)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _businessRules = rules;
        }

        public async Task<CreatedCustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _businessRules.CustomerNameCanNotBeDuplicatedWhenInserted(request.Name);

            Customer mappedCustomer = _mapper.Map<Customer>(request);
            Customer createdCustomer = await _customerRepository.AddAsync(mappedCustomer);
            CreatedCustomerDto createdCustomerDto = _mapper.Map<CreatedCustomerDto>(createdCustomer);
            return createdCustomerDto;
        }
    }
}
