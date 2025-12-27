using E_Commerce.Domin.Contract;
using E_Commerce.Domin.Entities;
using E_Commerce.Domin.Entities.ProductModule;
using E_Commerce.Presistence.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce.Presistence.Data.DataSeed
{
    public class DataInitializar : IDataInitializar
    {
        private readonly StoreDbContext _dbContext;

        public DataInitializar(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InitializeAsync()
        {
            try
            {
                var HasBrand = await _dbContext.ProductBrands.AnyAsync();
                var HasType = await _dbContext.ProductTypes.AnyAsync();
                var HasProduct = await _dbContext.Products.AnyAsync();

                if (HasBrand && HasType && HasProduct) return;

                if (!HasBrand)
                  await  DataSeedFromFileAsync<ProductBrand, int>("brands.json", _dbContext.ProductBrands);

                if (!HasType)
                    await DataSeedFromFileAsync<ProductType, int>("types.json", _dbContext.ProductTypes);

                 await SaveDataAsync();

                if (!HasProduct)
                    await DataSeedFromFileAsync<Product, int>("products.json", _dbContext.Products);

                await SaveDataAsync();


            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error While Data Seed : {ex.Message} ");
            }

        }


        private async Task DataSeedFromFileAsync<T, TKey>(string fileName, DbSet<T> dbSet) where T : BaseEntity<TKey>
        {
            //D:\ASP .NET CORE (aliaa)\API 2\Project\E-Commerce\E-Commerce.Presistence\Data\DataSeed\FileJson\brands.json

            String FilePath = @$"..\E-Commerce.Presistence\Data\DataSeed\FileJson\{fileName}";

            if (!File.Exists(FilePath)) return;

            try
            {
                var dataStream = File.OpenRead(FilePath);
                var data = await  JsonSerializer.DeserializeAsync<List<T>>(dataStream, new JsonSerializerOptions()
                                                                           { PropertyNameCaseInsensitive = true });

                if (data is not null)
                {
                  await  dbSet.AddRangeAsync(data);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error While Read File : {fileName} and {ex.Message} " );
            }

        }

        private async Task SaveDataAsync()
        {
          await  _dbContext.SaveChangesAsync();
        }
    }
}
