using InventoryManagementSystem.Application.Features.Products.Commands.DTOs;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Products.Queries.GetProductById
{
    public record GetProductByIdQuery(Guid id) : IRequest<ProductDto>;
}
