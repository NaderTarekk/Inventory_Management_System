using InventoryManagementSystem.Application.Features.Users.Commands.DTOs;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Users.Commands.UpdateUser
{
    public record UpdateUserCommand(UserDto userDto) : IRequest<Unit>;
}
