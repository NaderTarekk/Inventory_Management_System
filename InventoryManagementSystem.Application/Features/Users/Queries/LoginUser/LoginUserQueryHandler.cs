using InventoryManagementSystem.Domain.Interfaces;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Users.Queries.LoginUser
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, string>
    {
        private readonly IUserRepository _repo;
        public LoginUserQueryHandler(IUserRepository repo)
        {
            _repo = repo;
        }
        public async Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _repo.LoginAsync(request.user);
            return result;
        }
    }
}
