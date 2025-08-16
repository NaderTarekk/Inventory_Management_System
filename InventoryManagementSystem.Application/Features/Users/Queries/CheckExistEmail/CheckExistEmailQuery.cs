using MediatR;

namespace InventoryManagementSystem.Application.Features.Users.Queries.CheckExistEmail
{
    public record CheckExistEmailQuery(string email) : IRequest<bool>;
}
