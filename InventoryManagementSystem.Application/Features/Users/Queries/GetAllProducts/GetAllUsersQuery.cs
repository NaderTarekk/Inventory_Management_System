using InventoryManagementSystem.Application.Features.Users.Commands.DTOs;
using InventoryManagementSystem.Domain.Entities;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Users.Queries.GetAllUsers
{
    public record GetAllUsersQuery : IRequest<List<User>>;
}
