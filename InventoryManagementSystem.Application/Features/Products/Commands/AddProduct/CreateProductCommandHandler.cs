using AutoMapper;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.Interfaces;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Products.Commands.AddProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Unit>
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mappedProduct = _mapper.Map<Product>(request.productDto);
                mappedProduct.CreatedAt = DateTime.UtcNow;
                await _repo.CreateAsync(mappedProduct);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("حدث خطأ أثناء إضافة المنتج", ex);
            }
        }
    }
}
