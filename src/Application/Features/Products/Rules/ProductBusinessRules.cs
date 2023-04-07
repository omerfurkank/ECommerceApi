using Application.Repositories;

namespace Application.Features.Products.Rules;

public class ProductBusinessRules
{
    private readonly IProductRepository _repository;
    public ProductBusinessRules(IProductRepository repository)
    {
        _repository = repository;
    }
    public async Task ProductNameCanNotBeDuplicatedWhenInserted(string productName)
    {
        var result = await _repository.GetAsync(p => p.Name == productName);

        if (result != null) throw new Exception("product already exist");
    }
}
