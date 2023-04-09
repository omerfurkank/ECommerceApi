using Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Rules;
public class OrderBusinessRules
{
    private readonly IOrderRepository _orderRepository;

    public OrderBusinessRules(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
}
