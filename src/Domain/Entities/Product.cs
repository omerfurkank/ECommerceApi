using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Product : Entity
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
    public int Price { get; set; }
    public Category Category { get; set; }

    public Product()
    {
    }

    public Product(int id, int categoryId, string name, int stock, int price)
    {
        Id = id;
        CategoryId = categoryId;
        Name = name;
        Stock = stock;
        Price = price;
    }
}
