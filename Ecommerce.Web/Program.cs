
using E_Commerce.Domin.Contract;
using E_Commerce.Presistence.Data.DataSeed;
using E_Commerce.Presistence.Data.DbContexts;
using E_Commerce.Presistence.Repositories;
using E_Commerce.Services.Abstraction.ProductService;
using E_Commerce.Services.BussniceService;
using E_Commerce.Services.Mapping;
using Ecommerce.Web.Extentions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Ecommerce.Web
{
    public class Program
    {
      
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IDataInitializar, DataInitializar>();
            builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
            builder.Services.AddScoped<IProductService, ProductService>();
            //builder.Services.AddTransient<ProductPictureUrlResolver>(); 
            builder.Services.AddAutoMapper(typeof(ProductProfile).Assembly);

            var app = builder.Build();

            #region ExtentionMethod
            await app.CreatemigratonAsync();
            await app.DataBaseSeedingAsync();
            #endregion




            //try
            //{
            //    using (var scope = app.Services.CreateScope())
            //    {

            //        var context = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
            //        var Initializer = scope.ServiceProvider.GetRequiredService<IDataInitializar>();
            //        context.Database.Migrate();
            //        Initializer.Initialize();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    var logger = app.Services.GetRequiredService<ILogger<Program>>();
            //    logger.LogError(ex, "An error occurred while migrating or seeding the database.");
            //}

            #region DataSeeding
            //using var scope1 = app.Services.CreateScope();
            //var servicesInitializer = scope1.ServiceProvider.GetRequiredService<IDataInitializar>();
            //servicesInitializer.Initialize();
            #endregion






            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.MapControllers();

            app.Run();
        }
    }
}
