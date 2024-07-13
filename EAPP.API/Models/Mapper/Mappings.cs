using AutoMapper;
using EApp.Domain.Entities.Concrete;
using EAPP.API.Models.DTOs;

namespace EAPP.API.Models.Mapper
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<AppUser, CreateAppUserDTO>().ReverseMap();

            CreateMap<Product,GetProductDTO>().ReverseMap();
            CreateMap<Product,CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateCategoryDTO>().ReverseMap();

            CreateMap<AppRole,CreateRoleDTO>().ReverseMap();

            CreateMap<Order, CreateOrderDTO>().ReverseMap();
        }
    }
}
