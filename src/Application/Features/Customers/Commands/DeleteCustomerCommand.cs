using Application.Features.Customers.Dtos;
using Application.Features.Customers.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customers.Commands;

public class DeleteCustomerCommand : IRequest<DeletedCustomerDto>
{
    public int Id { get; set; }
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCustomerCommand, DeletedCustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly CustomerBusinessRules _businessRules;

        public DeleteCategoryCommandHandler(ICustomerRepository customerRepository, IMapper mapper, CustomerBusinessRules rules)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _businessRules = rules;
        }

        public async Task<DeletedCustomerDto> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer mappedCustomer = _mapper.Map<Customer>(request);
            Customer deletedCustomer = await _customerRepository.DeleteAsync(mappedCustomer);
            DeletedCustomerDto deletedCustomerDto = _mapper.Map<DeletedCustomerDto>(deletedCustomer);
            return deletedCustomerDto;
        }
    }
}