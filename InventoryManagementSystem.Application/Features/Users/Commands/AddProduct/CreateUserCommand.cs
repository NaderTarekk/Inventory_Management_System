using InventoryManagementSystem.Application.Features.Users.Commands.DTOs;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Users.Commands.AddUser
{
    public record CreateUserCommand(UserDto userDto) : IRequest<Unit>;
}
