using AutoMapper;
using InventoryManagementSystem.Application.Features.Products.Commands.DTOs;
using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Application.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
        }
    }
}
