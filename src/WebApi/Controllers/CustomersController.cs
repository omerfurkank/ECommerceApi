using Application.Features.Customers.Commands;
using Application.Features.Customers.Dtos;
using Application.Features.Customers.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CustomersController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        IList<GetCustomerDto> result = await Mediator.Send(
            new GetListCustomerQuery() { PageRequest = pageRequest });
        return Ok(result);
    }
    [HttpGet("{Id}")]
    public async Task<IActionResult> Get([FromRoute] GetByIdCustomerQuery getByIdCustomerQuery)
    {
        GetCustomerDto result = await Mediator.Send(getByIdCustomerQuery);
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCustomerCommand command)
    {
        CreatedCustomerDto result = await Mediator.Send(command);
        return Created("", result);
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerCommand command)
    {
        UpdatedCustomerDto result = await Mediator.Send(command);
        return Ok(result);
    }
    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteCustomerCommand command)
    {
        DeletedCustomerDto result = await Mediator.Send(command);
        return Ok(result);
    }
}

