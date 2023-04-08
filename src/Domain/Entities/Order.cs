using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Order : Entity
{
    public int CustomerId { get; set; }
    public string Description { get; set; }
    public string Adress { get; set; }

    public Customer Customer { get; set; }
    public ICollection<Product> Products { get; set; }

    public Order()
    {
        Products = new HashSet<Product>();
    }

    public Order(int id, int customerId, string description, string adress, ICollection<Product> products)
    {
        Id = id;
        CustomerId = customerId;
        Description = description;
        Adress = adress;
        Products = products;
    }
}
