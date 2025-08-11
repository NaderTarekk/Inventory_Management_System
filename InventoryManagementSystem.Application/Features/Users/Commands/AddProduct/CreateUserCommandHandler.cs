using AutoMapper;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.Interfaces;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Users.Commands.AddUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mappedUser = _mapper.Map<User>(request.userDto);
                mappedUser.CreatedAt = DateOnly.FromDateTime(DateTime.Now);

                await _repo.CreateAsync(mappedUser);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("حدث خطأ أثناء إضافة المسخدم", ex);
            }
        }
    }
}
