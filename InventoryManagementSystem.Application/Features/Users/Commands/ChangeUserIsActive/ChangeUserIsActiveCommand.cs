using MediatR;

namespace InventoryManagementSystem.Application.Features.Users.Commands.ChangeUserIsActive
{
    public record ChangeUserIsActiveCommand(Guid id, bool activity):IRequest<Unit>;
}
