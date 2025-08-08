using AutoMapper;
using InventoryManagementSystem.Application.Features.Categories.Commands.UpdateCategory;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.Interfaces;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Categorys.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Category = _mapper.Map<Category>(request.categoryDto);
                await _repo.UpdateAsync(Category);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("حدث خطأ أثناء تعديل المنتج", ex);
            }
        }
    }
}
