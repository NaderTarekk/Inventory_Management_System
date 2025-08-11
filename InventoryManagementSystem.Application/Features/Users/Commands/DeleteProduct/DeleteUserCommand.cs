using MediatR;

namespace InventoryManagementSystem.Application.Features.Users.Commands.UpdateUser
{
    public record DeleteUserCommand(Guid id) : IRequest<Unit>;
}
