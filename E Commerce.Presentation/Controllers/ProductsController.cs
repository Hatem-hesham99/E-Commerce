using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Services.Abstraction.ProductService;
using E_Commerce.Shared.DTOS;
using Microsoft.AspNetCore.Mvc;


namespace E_Commerce.Presentation.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts()
        {
            var data = await _productService.GetAllProudectAsync();
            return Ok(data);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            var data = await _productService.GetProudectByIdAsync(id);
            return Ok(data);
        }

        [HttpGet("Type")]
        public async Task<ActionResult<IEnumerable<TypeDTO>>> GetAllTypes()
        {
            var data = await _productService.GetAllTypeAsync();
            return Ok(data);
        }

        [HttpGet("Brand")]
        public async Task<ActionResult<IEnumerable<BrandDTO>>> GetAllBrands()
        {
            var data = await _productService.GetAllBrandAsync();
            return Ok(data);
        }

    }
}
