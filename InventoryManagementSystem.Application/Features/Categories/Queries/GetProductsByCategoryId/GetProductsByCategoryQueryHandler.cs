using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.Interfaces;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Categories.Queries.GetProductsByCategoryId
{
    public class GetProductsByCategoryQueryHandler : IRequestHandler<GetProductsByCategoryQuery, List<Product>>
    {
        private readonly ICategoryRepository _repo;
        public GetProductsByCategoryQueryHandler(ICategoryRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<Product>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _repo.GetProductsByCategoryId(request.id);
            return result;
        }
    }
}
