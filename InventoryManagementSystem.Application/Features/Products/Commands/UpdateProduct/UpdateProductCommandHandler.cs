using AutoMapper;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.Interfaces;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request.productDto);
            await _repo.UpdateAsync(product);
            return Unit.Value;
        }
    }
}
