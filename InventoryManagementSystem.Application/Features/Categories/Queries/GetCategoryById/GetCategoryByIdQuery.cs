using InventoryManagementSystem.Application.Features.Categories.DTOs;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Categories.Queries.GetCategoryById
{
    public record GetCategoryByIdQuery(int id) : IRequest<CategoryDto>;
}
