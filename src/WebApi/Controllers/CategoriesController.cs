using Application.Features.Categories.Commands;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            IList<GetCategoryDto> result = await Mediator.Send(
                new GetListCategoryQuery() { PageRequest = pageRequest });
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdCategoryQuery getByIdCategoryQuery)
        {
            GetCategoryDto result = await Mediator.Send(getByIdCategoryQuery);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCategoryCommand command)
        {
            CreatedCategoryDto result = await Mediator.Send(command);
            return Created("", result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand command)
        {
            UpdatedCategoryDto result = await Mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCategoryCommand command)
        {
            DeletedCategoryDto result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
