using AutoMapper;
using InventoryManagementSystem.Application.Features.Products.Commands.DTOs;
using InventoryManagementSystem.Domain.Interfaces;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        public GetAllUsersQueryHandler(IProductRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var products = await _repo.GetAllAsync();
                return _mapper.Map<List<ProductDto>>(products);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("حدث خطأ أثناء تحميل المنتجات", ex);
            }
        }
    }
}
