using AutoMapper;
using InventoryManagementSystem.Application.Features.Categories.DTOs;
using InventoryManagementSystem.Application.Features.Categories.Queries.GetCategoryById;
using InventoryManagementSystem.Application.Features.Products.Commands.DTOs;
using InventoryManagementSystem.Domain.Interfaces;
using MediatR;

namespace InventoryManagementSystem.Categories.Features.GetCategoryById.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;
        public GetCategoryByIdQueryHandler(ICategoryRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var getProduct = await _repo.GetByIdAsync(request.id);
                var mapped = _mapper.Map<CategoryDto>(getProduct);
                return mapped;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("حدث خطأ أثناء تحميل المنتج", ex);
            }
        }
    }
}
