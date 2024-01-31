using AutoMapper;
using GeekShopping.ProductAPI.DTOs;
using GeekShopping.ProductAPI.Entities;

namespace GeekShopping.ProductAPI.Configurations;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<Product, ProductDTO>().ReverseMap();        
    }
}