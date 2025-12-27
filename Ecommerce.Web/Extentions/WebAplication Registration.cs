using E_Commerce.Domin.Contract;
using E_Commerce.Presistence.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Ecommerce.Web.Extentions
{
    public static class WebAplication_Registration
    {

        public static async Task CreatemigratonAsync (this WebApplication app)
        {
          await using (var scope = app.Services.CreateAsyncScope())
          {
             var context = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
             await context.Database.MigrateAsync();
          }
           
        }

        public static async Task DataBaseSeedingAsync(this WebApplication app)
        {
            await using ( var scope =  app.Services.CreateAsyncScope())
            {
               var dataInitializar = scope.ServiceProvider.GetRequiredService<IDataInitializar>();
               await dataInitializar.InitializeAsync();
            }
        }


    }
}
