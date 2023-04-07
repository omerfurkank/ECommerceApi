using Core.Persistence.Repositories;

namespace Application.Features.Products.Dtos;

public class GetProductDto : Dto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CategoryName { get; set; }
    public int Stock { get; set; }
    public int Price { get; set; }
}
