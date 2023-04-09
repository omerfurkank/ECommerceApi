using Core.Persistence.Repositories;

namespace Application.Features.Orders.Dtos;

public class DeletedOrderDto : Dto
{
    public int Id { get; set; }
}
