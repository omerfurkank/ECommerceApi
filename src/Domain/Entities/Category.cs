using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Category : Entity
{
    public string Name { get; set; }
    public ICollection<Product> Products { get; set; }

    public Category()
    {
        Products = new HashSet<Product>();
    }

    public Category(int id, string name)
    {
        Id = id;
        Name = name;
    }
}