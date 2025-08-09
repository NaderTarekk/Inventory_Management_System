using AutoMapper;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.Interfaces;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Categories.Commands.AddCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repo.CreateAsync(request.name);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("حدث خطأ أثناء إضافة الصنف", ex);
            }
        }
    }
}
