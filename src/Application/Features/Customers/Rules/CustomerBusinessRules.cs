using Application.Repositories;

namespace Application.Features.Customers.Rules;
public class CustomerBusinessRules
{
    private readonly ICustomerRepository _repository;
    public CustomerBusinessRules(ICustomerRepository repository)
    {
        _repository = repository;
    }
    public async Task CustomerNameCanNotBeDuplicatedWhenInserted(string customerName)
    {
        var result = await _repository.GetAsync(c => c.Name == customerName);

        if (result != null) throw new Exception("customer already exist");
    }
}
