using Application.Features.Orders.Commands;
using Application.Features.Orders.Dtos;
using Application.Features.Orders.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrdersController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        IList<GetOrderDto> result = await Mediator.Send(
            new GetListOrderQuery() { PageRequest = pageRequest });
        return Ok(result);
    }
    [HttpGet("{Id}")]
    public async Task<IActionResult> Get([FromRoute] GetByIdOrderQuery getByIdOrderQuery)
    {
        GetOrderDto result = await Mediator.Send(getByIdOrderQuery);
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateOrderCommand command)
    {
        CreatedOrderDto result = await Mediator.Send(command);
        return Created("", result);
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateOrderCommand command)
    {
        UpdatedOrderDto result = await Mediator.Send(command);
        return Ok(result);
    }
    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteOrderCommand command)
    {
        DeletedOrderDto result = await Mediator.Send(command);
        return Ok(result);
    }
}
