using MediatR;

namespace InventoryManagementSystem.Application.Features.Products.Commands.ChangeIsActive
{
    public record ChangeIsActiveCommand(Guid id, bool activity):IRequest<Unit>;
}
