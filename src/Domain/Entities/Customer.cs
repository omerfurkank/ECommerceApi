using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Customer : Entity
{
    public string Name { get; set; }
    public ICollection<Order> Orders { get; set; }
    public Customer()
    {
        Orders = new HashSet<Order>();
    }
    public Customer(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
