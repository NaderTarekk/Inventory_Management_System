using InventoryManagementSystem.Domain.Interfaces;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Users.Queries.CheckExistEmail
{
    public class CheckExistEmailQueryHandler : IRequestHandler<CheckExistEmailQuery, bool>
    {
        private readonly IUserRepository _repo;
        public CheckExistEmailQueryHandler(IUserRepository repo)
        {
            _repo = repo;
        }
        public async Task<bool> Handle(CheckExistEmailQuery request, CancellationToken cancellationToken)
        {
            var result = await _repo.CheckEmailIsExistAsync(request.email);
            return result;
        }
    }
}
