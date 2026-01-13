using AutoMapper;
using E_Commerce.Domin.Contract;
using E_Commerce.Domin.Entities.ProductModule;
using E_Commerce.Services.Abstraction.ProductService;
using E_Commerce.Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Services.BussniceService
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork , IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProudectAsync()
        {
            var Data = await _unitOfWork.GetGenericRepository<Product, int>().GetAllAsync();

            var Products =  _mapper.Map<IEnumerable<ProductDTO>>( Data );

            return Products;

        }
        public async Task<ProductDTO> GetProudectByIdAsync(int id)
        {
            var Data = await _unitOfWork.GetGenericRepository<Product, int>().GetByIdAsync(id);

            var Products = _mapper.Map<ProductDTO>(Data);

            return Products;
        }
        public async Task<IEnumerable<TypeDTO>> GetAllTypeAsync()
        {
           var data = await _unitOfWork.GetGenericRepository<ProductType,int>().GetAllAsync();
           var types = _mapper.Map<IEnumerable<TypeDTO>>(data);
           return types;
        }
        public async Task<IEnumerable<BrandDTO>> GetAllBrandAsync()
        {
            var data = await _unitOfWork.GetGenericRepository<ProductBrand, int>().GetAllAsync();
            var brands = _mapper.Map<IEnumerable<BrandDTO>>(data);
            return brands;
        }
    }
}
