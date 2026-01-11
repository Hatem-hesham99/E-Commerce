using E_Commerce.Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Services.Abstraction.ProductService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProudectAsync(); 
        Task<ProductDTO> GetProudectByIdAsync(int id);
        Task<IEnumerable<BrandDTO>> GetAllBrandAsync();
        Task<IEnumerable<TypeDTO>> GetAllTypeAsync();



    }
}
