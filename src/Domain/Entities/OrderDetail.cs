using Core.Persistence.Repositories;

namespace Domain.Entities;
public class OrderDetail : Entity
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }

    public Order Order { get; set; }
    public Product Product { get; set; }
    public OrderDetail()
    {

    }

    public OrderDetail(int id, int orderId, int productId)
    {
        Id = id;
        OrderId = orderId;
        ProductId = productId;
    }
}
