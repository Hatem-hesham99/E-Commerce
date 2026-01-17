using AutoMapper;
using E_Commerce.Domin.Entities.ProductModule;
using E_Commerce.Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Services.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        {
            CreateMap<Product,ProductDTO>()
                .ForMember(dis=>dis.ProductBrand, op=>op.MapFrom(src=>src.ProductBrand.Name))
                .ForMember(dis=>dis.ProductType,op=>op.MapFrom(src=>src.ProductType.Name))
                .ForMember(des=>des.PictureUrl, op=>op.MapFrom<ProductPictureUrlResolver>())
                .ReverseMap();

            CreateMap<ProductType,TypeDTO>().ReverseMap();

            CreateMap<ProductBrand,BrandDTO>().ReverseMap();
        }
    }
}
