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
            CreateMap<Product,ProductListDTO>().ReverseMap();
            CreateMap<Product,CreateProductDTO>().ReverseMap();
        }
    }
}
