using InventoryManagementSystem.Application.Features.Products.Commands.DTOs;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Products.Commands.AddProduct
{
    public record CreateProductCommand(ProductDto productDto) : IRequest<Unit>;
}
