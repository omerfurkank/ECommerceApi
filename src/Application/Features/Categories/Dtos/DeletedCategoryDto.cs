using Core.Persistence.Repositories;

namespace Application.Features.Categories.Dtos;

public class DeletedCategoryDto : Dto
{
    public string Name { get; set; }
}
