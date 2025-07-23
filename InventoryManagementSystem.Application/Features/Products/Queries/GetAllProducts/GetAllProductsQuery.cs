using InventoryManagementSystem.Application.Features.Products.Commands.DTOs;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Products.Queries.GetAllProducts
{
    public record GetAllProductsQuery : IRequest<List<ProductDto>>;
}
