using MediatR;

namespace InventoryManagementSystem.Application.Features.Products.Commands.DeleteProduct
{
    public record DeleteProductCommand(Guid id) : IRequest<Unit>;
}
