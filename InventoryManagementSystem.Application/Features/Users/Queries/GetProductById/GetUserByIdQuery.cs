using InventoryManagementSystem.Application.Features.Users.Commands.DTOs;
using InventoryManagementSystem.Domain.Entities;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Users.Queries.GetUserById
{
    public record GetUserByIdQuery(Guid id) : IRequest<User>;
}
