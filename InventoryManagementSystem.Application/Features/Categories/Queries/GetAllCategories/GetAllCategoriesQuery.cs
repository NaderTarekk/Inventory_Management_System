using InventoryManagementSystem.Domain.Entities;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Categories.Queries.GetAllCategories
{
    public record GetAllCategoriesQuery : IRequest<List<Category>>;
}
