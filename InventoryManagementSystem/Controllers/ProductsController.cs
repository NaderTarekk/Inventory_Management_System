using InventoryManagementSystem.Application.Features.Products.Commands.AddProduct;
using InventoryManagementSystem.Application.Features.Products.Commands.DeleteProduct;
using InventoryManagementSystem.Application.Features.Products.Commands.DTOs;
using InventoryManagementSystem.Application.Features.Products.Commands.UpdateProduct;
using InventoryManagementSystem.Application.Features.Products.Queries.GetAllProducts;
using InventoryManagementSystem.Application.Features.Products.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] ProductDto cmd)
        {
            var result = await _mediator.Send(new CreateProductCommand(cmd));
            return Ok(result);
        }
        
        [HttpDelete]
        public async Task<ActionResult<Guid>> Delete([FromBody] Guid id)
        {
            var result = await _mediator.Send(new DeleteProductCommand(id));
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] ProductDto cmd)
        {
            var result = await _mediator.Send(new UpdateProductCommand(cmd));
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllProductsQuery());
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ProductDto>> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(result);
        }
    }
}
