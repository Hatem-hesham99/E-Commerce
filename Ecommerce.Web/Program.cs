
using E_Commerce.Presistence.Data.DbContexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Web
{
    public class Program
    {
      
        public static void Main(string[] args)
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

            var app = builder.Build();


            //try
            //{
            //    using (var scope = app.Services.CreateScope())
            //    {
            //        var services = scope.ServiceProvider;
            //        var context = services.GetRequiredService<StoreDbContext>();
            //       // var loger = services.GetRequiredService<ILogger<Program>>();
            //       //dfbdffg
            //        context.Database.Migrate();
            //    }
            //}
            //catch(Exception ex)
            //{
            //    var logger = app.Services.GetRequiredService<ILogger<Program>>();
            //    logger.LogError(ex, "An error occurred while migrating or seeding the database.");
            //}


           

           

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
