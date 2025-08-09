using InventoryManagementSystem.Application.Features.Categories.Commands.AddCategory;
using InventoryManagementSystem.Application.Features.Categories.Commands.DeleteProduct;
using InventoryManagementSystem.Application.Features.Categories.Commands.UpdateCategory;
using InventoryManagementSystem.Application.Features.Categories.DTOs;
using InventoryManagementSystem.Application.Features.Categories.Queries.GetAllCategories;
using InventoryManagementSystem.Application.Features.Categories.Queries.GetCategoryById;
using InventoryManagementSystem.Application.Features.Categories.Queries.GetProductsByCategoryId;
using InventoryManagementSystem.Application.Features.Products.Queries.GetProductById;
using InventoryManagementSystem.Domain.Entities;
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
        public async Task<ActionResult<Guid>> Create([FromBody] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("Name is required.");

            var result = await _mediator.Send(new CreateCategoryCommand(name.Trim()));
            return Ok(result); 
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteCategoryCommand(id));
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<int>> Update([FromForm] CategoryDto data)
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
        public async Task<ActionResult<List<Product>>> GetProductsByCategoryId([FromQuery] int id)
        {
            var result = await _mediator.Send(new GetProductsByCategoryQuery(id));
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<CategoryDto>> GetById( int id)
        {
            var result = await _mediator.Send(new GetCategoryByIdQuery(id));
            return Ok(result);
        }
    }
}
