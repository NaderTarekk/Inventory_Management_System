using AutoMapper;
using InventoryManagementSystem.Application.Features.Users.Commands.DTOs;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.Interfaces;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;
        public GetUserByIdQueryHandler(IUserRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var getProduct = await _repo.GetByIdAsync(request.id);
                return getProduct;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("حدث خطأ أثناء تحميل المستخدم", ex);
            }
        }
    }
}
