using InventoryManagementSystem.Application.Features.Products.Commands.DTOs;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Products.Commands.UpdateProduct
{
    public record UpdateProductCommand(ProductDto productDto) : IRequest<Unit>;
}
