using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Domin.Entities.ProductModule
{
    public class Product : BaseEntity<int>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        public string? PictureUrl { get; set; }
        public decimal Price { get; set; }

        #region Relations


        public int TypeId { get; set; }
        public ProductType ProductType { get; set; }
       

        public int BrandId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        #endregion

    }
}
