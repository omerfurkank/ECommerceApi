using Core.Persistence.Repositories;

namespace Application.Features.Customers.Dtos;

public class UpdatedCustomerDto : Dto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
