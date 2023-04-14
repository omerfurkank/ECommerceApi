using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;

public class Customer : Entity
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public User User { get; set; }
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
