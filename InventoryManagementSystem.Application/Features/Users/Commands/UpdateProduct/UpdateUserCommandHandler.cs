using AutoMapper;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.Interfaces;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = _mapper.Map<User>(request.userDto);
                product.Id = (Guid)request.userDto.Id;
                await _repo.UpdateAsync(product);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("حدث خطأ أثناء تعديل المستخدم", ex);
            }
        }
    }
}
