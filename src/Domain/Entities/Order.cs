using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Order : Entity
{
    public int CustomerId { get; set; }
    public string Description { get; set; }
    public string Adress { get; set; }

    public Customer Customer { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; }

    public Order()
    {
        OrderDetails = new HashSet<OrderDetail>();
    }

    public Order(int id, int customerId, string description, string adress)
    {
        Id = id;
        CustomerId = customerId;
        Description = description;
        Adress = adress;
    }
}
