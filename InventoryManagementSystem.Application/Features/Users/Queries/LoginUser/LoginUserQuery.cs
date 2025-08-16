using InventoryManagementSystem.Domain.DTOs;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Users.Queries.LoginUser
{
    public record LoginUserQuery(LoginUserDto user): IRequest<string>;
}
