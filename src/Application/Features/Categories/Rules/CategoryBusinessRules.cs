using Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Rules;

public class CategoryBusinessRules
{
    private readonly ICategoryRepository _repository;
    public CategoryBusinessRules(ICategoryRepository repository)
    {
        _repository = repository;
    }
    public async Task CategoryNameCanNotBeDuplicatedWhenInserted(string categoryName)
    {
        var result = await _repository.GetAsync(c => c.Name == categoryName);

        if (result != null) throw new Exception("category already exist");
    }
}
