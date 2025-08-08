using AutoMapper;
using InventoryManagementSystem.Application.Features.Categories.DTOs;
using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Application.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
        }
    }
}
