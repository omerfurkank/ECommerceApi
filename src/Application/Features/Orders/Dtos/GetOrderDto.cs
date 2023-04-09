using Core.Persistence.Repositories;

namespace Application.Features.Orders.Dtos;

public class GetOrderDto : Dto
{
    public int Id { get; set; }
    public int CustomerName { get; set; }
    public string Description { get; set; }
    public string Adress { get; set; }
}
