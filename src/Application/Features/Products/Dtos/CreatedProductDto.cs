using Core.Persistence.Repositories;

namespace Application.Features.Products.Dtos;

public class CreatedProductDto : Dto
{
    public int Id { get; set; }
    public string CategoryId { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
    public int Price { get; set; }
}
