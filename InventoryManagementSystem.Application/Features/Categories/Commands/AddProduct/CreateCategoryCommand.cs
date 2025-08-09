using InventoryManagementSystem.Application.Features.Categories.DTOs;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Categories.Commands.AddCategory
{
    public record CreateCategoryCommand(string name) : IRequest<Unit>;
}
