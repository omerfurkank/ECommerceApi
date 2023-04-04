using Application.Features.Products.Commands;
using Application.Features.Products.Dtos;
using Application.Features.Products.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            IList<GetProductDto> result = await Mediator.Send(
                new GetListProductQuery() {PageRequest=pageRequest});
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdProductQuery getByIdProductQuery)
        {
            GetProductDto result = await Mediator.Send(getByIdProductQuery);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductCommand command)
        {
            CreatedProductDto result = await Mediator.Send(command);
            return Created("", result);
        }
    }
}
