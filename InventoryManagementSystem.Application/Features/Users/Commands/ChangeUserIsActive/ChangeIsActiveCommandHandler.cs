using InventoryManagementSystem.Domain.Interfaces;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Users.Commands.ChangeUserIsActive
{
    public class ChangeIsActiveCommandHandler : IRequestHandler<ChangeUserIsActiveCommand, Unit>
    {
        private readonly IUserRepository _repo;
        public ChangeIsActiveCommandHandler(IUserRepository repo)
        {
            _repo = repo;
        }
        public async Task<Unit> Handle(ChangeUserIsActiveCommand request, CancellationToken cancellationToken)
        {
            await _repo.ChangeIsActiveAsync(request.id, request.activity);
            return Unit.Value;
        }
    }
}
