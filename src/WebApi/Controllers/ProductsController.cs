using Application.Features.Products.Commands;
using Application.Features.Products.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductCommand command)
        {
            CreatedProductDto result = await Mediator.Send(command);
            return Created("", result);
        }
    }
}
