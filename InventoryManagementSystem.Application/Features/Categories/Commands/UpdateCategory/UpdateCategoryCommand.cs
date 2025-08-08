using InventoryManagementSystem.Application.Features.Categories.DTOs;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Categories.Commands.UpdateCategory
{
    public record UpdateCategoryCommand(CategoryDto categoryDto) : IRequest<Unit>;
}
