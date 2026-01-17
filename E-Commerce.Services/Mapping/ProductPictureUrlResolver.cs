using AutoMapper;
using E_Commerce.Domin.Entities.ProductModule;
using E_Commerce.Shared.DTOS;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Services.Mapping
{
    public class ProductPictureUrlResolver : IValueResolver<Product, ProductDTO, string>
    {
        private readonly IConfiguration _configuration;

        public ProductPictureUrlResolver(IConfiguration configuration )
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
            if(string.IsNullOrEmpty(source.PictureUrl))
                return string.Empty;

            if(source.PictureUrl.StartsWith("http"))
              return source.PictureUrl;

            string baseUrl = _configuration.GetSection("ApiUrls")["CdnUrl"];
            if( string.IsNullOrEmpty(baseUrl)) return string.Empty;

            return $"{baseUrl}{source.PictureUrl}";


        }
    }
}
