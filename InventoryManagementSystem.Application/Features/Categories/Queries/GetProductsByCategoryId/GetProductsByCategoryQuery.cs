using InventoryManagementSystem.Domain.Entities;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Categories.Queries.GetProductsByCategoryId
{
    public record GetProductsByCategoryQuery(int id):IRequest<List<Product>>;
}
