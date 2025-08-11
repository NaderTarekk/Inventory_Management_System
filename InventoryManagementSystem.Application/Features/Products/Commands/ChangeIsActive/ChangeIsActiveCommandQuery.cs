using InventoryManagementSystem.Domain.Interfaces;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Products.Commands.ChangeIsActive
{
    public class ChangeIsActiveCommandHandler : IRequestHandler<ChangeIsActiveCommand, Unit>
    {
        private readonly IProductRepository _repo;
        public ChangeIsActiveCommandHandler(IProductRepository repo)
        {
            _repo = repo;
        }
        public async Task<Unit> Handle(ChangeIsActiveCommand request, CancellationToken cancellationToken)
        {
            await _repo.ChangeIsActiveAsync(request.id, request.activity);
            return Unit.Value;
        }
    }
}
