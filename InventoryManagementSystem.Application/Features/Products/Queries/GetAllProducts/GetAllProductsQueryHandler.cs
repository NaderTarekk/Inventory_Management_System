using AutoMapper;
using InventoryManagementSystem.Application.Features.Products.Commands.DTOs;
using InventoryManagementSystem.Domain.Interfaces;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        public GetAllProductsQueryHandler(IProductRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repo.GetAllAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}
