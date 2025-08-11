using AutoMapper;
using InventoryManagementSystem.Application.Features.Products.Commands.DTOs;
using InventoryManagementSystem.Application.Features.Users.Commands.DTOs;
using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Application.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>()
    .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
