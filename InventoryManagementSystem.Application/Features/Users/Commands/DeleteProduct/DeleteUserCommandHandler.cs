using InventoryManagementSystem.Domain.Interfaces;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Users.Commands.UpdateUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUserRepository _repo;
        public DeleteUserCommandHandler(IUserRepository repo)
        {
            _repo = repo;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repo.DeleteAsync(request.id);
                return Unit.Value;
            }
            catch (Exception ex) 
            {
                throw new ApplicationException("حدث خطأ أثناء إزالة المنتج", ex);
            }
        }
    }
}
