using Core.Persistence.Repositories;

namespace Application.Features.Categories.Dtos;

public class CreatedCategoryDto : Dto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
