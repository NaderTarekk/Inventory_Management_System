using InventoryManagementSystem.Application.Features.Categories.Commands.DeleteProduct;
using InventoryManagementSystem.Domain.Interfaces;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _repo;
        public DeleteCategoryCommandHandler(ICategoryRepository repo)
        {
            _repo = repo;
        }
        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repo.DeleteAsync(request.id);
                return Unit.Value;
            }
            catch (Exception ex) 
            {
                throw new ApplicationException("حدث خطأ أثناء إزالة الصنف", ex);
            }
        }
    }
}
