using InventoryManagementSystem.Application.Features.Products.Commands.AddProduct;
using InventoryManagementSystem.Application.Features.Products.Commands.ChangeIsActive;
using InventoryManagementSystem.Application.Features.Products.Commands.DeleteProduct;
using InventoryManagementSystem.Application.Features.Products.Commands.DTOs;
using InventoryManagementSystem.Application.Features.Products.Commands.UpdateProduct;
using InventoryManagementSystem.Application.Features.Products.Queries.GetAllProducts;
using InventoryManagementSystem.Application.Features.Products.Queries.GetProductById;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Infrastructure.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly InventoryDbContext _ctx;
        IMediator _mediator;
        public ProductsController(IMediator mediator, InventoryDbContext ctx)
        {
            _mediator = mediator;
            _ctx = ctx;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromForm] ProductDto cmd, IFormFile? image)
        {
            string? imageUrl = null;

            if (image != null && image.Length > 0)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
                var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }
                imageUrl = $"/images/{fileName}";
            }

            cmd.ImageUrl = imageUrl;
            //using var ms = new MemoryStream();
            //await image.CopyToAsync(ms);
            //byte[] imageBytes = ms.ToArray();

            //cmd.ImageData = imageBytes;
            //cmd.ImageContentType = image.ContentType;

            var result = await _mediator.Send(new CreateProductCommand(cmd));
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteProductCommand(id));
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromForm] ProductDto data, IFormFile? image)
        {
            string? imageUrl = null;

            if (image != null && image.Length > 0)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
                var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }
                imageUrl = $"/images/{fileName}";
            }

            data.ImageUrl = imageUrl;
            var result = await _mediator.Send(new UpdateProductCommand(data));
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> ChangeIsActive(ChaneIsActive data)
        {
            var result = await _mediator.Send(new ChangeIsActiveCommand(data.id, data.activity));
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
