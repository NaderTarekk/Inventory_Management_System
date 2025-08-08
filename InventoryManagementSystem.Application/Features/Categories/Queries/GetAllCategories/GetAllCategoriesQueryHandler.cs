using AutoMapper;
using InventoryManagementSystem.Application.Features.Categories.DTOs;
using InventoryManagementSystem.Application.Features.Categories.Queries.GetAllCategories;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.Interfaces;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Categorys.Queries.GetAllCategorys
{
    public class GetAllCategoryiesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<Category>>
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;
        public GetAllCategoryiesQueryHandler(ICategoryRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<List<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var Categorys =  _repo.GetAllAsync();
                return _mapper.Map<List<Category>>(Categorys);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("حدث خطأ أثناء تحميل المنتجات", ex);
            }
        }
    }
}
