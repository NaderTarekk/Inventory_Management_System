using MediatR;

namespace InventoryManagementSystem.Application.Features.Categories.Commands.DeleteProduct
{
    public record DeleteCategoryCommand(int id) : IRequest<Unit>;
}
