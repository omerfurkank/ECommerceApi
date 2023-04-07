using Core.Persistence.Repositories;

namespace Application.Features.Categories.Dtos;

public class GetCategoryDto : Dto
{
    public int Id { get; set; }
    public string Name { get; set; }
}