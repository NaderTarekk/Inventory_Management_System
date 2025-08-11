using AutoMapper;
using InventoryManagementSystem.Application.Features.Users.Commands.DTOs;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.Interfaces;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;
        public GetAllUsersQueryHandler(IUserRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = _repo.GetAllAsync();
                return users;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("حدث خطأ أثناء تحميل المستخدمين", ex);
            }
        }
    }
}
