using InventoryManagementSystem.Application.Features.Categories.Commands.AddCategory;
using InventoryManagementSystem.Application.Features.Categories.Commands.DeleteProduct;
using InventoryManagementSystem.Application.Features.Categories.Commands.UpdateCategory;
using InventoryManagementSystem.Application.Features.Categories.DTOs;
using InventoryManagementSystem.Application.Features.Categories.Queries.GetAllCategories;
using InventoryManagementSystem.Application.Features.Categories.Queries.GetCategoryById;
using InventoryManagementSystem.Infrastructure.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly InventoryDbContext _ctx;
        IMediator _mediator;
        public CategoriesController(IMediator mediator, InventoryDbContext ctx)
        {
            _mediator = mediator;
            _ctx = ctx;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CategoryDto cmd)
        {
            var result = await _mediator.Send(new CreateCategoryCommand(cmd));
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteCategoryCommand(id));
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromForm] CategoryDto data)
        {
            var result = await _mediator.Send(new UpdateCategoryCommand(data));
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllCategoriesQuery());
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            var result = await _mediator.Send(new GetCategoryByIdQuery(id));
            return Ok(result);
        }
    }
}
