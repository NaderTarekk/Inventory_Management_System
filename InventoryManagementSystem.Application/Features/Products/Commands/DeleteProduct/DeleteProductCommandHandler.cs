using AutoMapper;
using InventoryManagementSystem.Domain.Interfaces;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IProductRepository _repo;
        public DeleteProductCommandHandler(IProductRepository repo)
        {
            _repo = repo;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
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
