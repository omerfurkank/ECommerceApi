using Core.Persistence.Repositories;

namespace Application.Features.Customers.Dtos;

public class CreatedCustomerDto : Dto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
