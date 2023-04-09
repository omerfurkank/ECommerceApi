using Core.Persistence.Repositories;

namespace Application.Features.Orders.Dtos;
public class CreatedOrderDto : Dto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string Description { get; set; }
    public string Adress { get; set; }
}
