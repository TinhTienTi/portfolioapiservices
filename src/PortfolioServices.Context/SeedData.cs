using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PortfolioServices.Model;
using PortfolioServices.Utilities;

namespace PortfolioServices.Context
{
    public class SeedData
    {
        public static async void InitializeDatabase(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<PortfoliServicesContext>(options => options.UseSqlServer(connectionString));

            var serviceProvider = services.BuildServiceProvider();

            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
          
            var ctx = scope.ServiceProvider.GetService<PortfoliServicesContext>();

            await ctx.Database.MigrateAsync();

            if (!await ctx.Database.EnsureCreatedAsync())
            {
                ctx.Database.Migrate();
                await EnsureData(ctx);
            }
        }

        private static async Task EnsureData(PortfoliServicesContext context)
        {

            #region -- Categories --

            List<Categories> categories = new List<Categories>();

            categories.Add(new Categories() { Tid = Guid.NewGuid(), CreatedAt = DateTimeOffset.UtcNow, Object = LanguageObjectConstants.Home, Priority = 0, Value = "Up" });
            categories.Add(new Categories() { Tid = Guid.NewGuid(), CreatedAt = DateTimeOffset.UtcNow, Object = LanguageObjectConstants.Home, Priority = 1, Value = "Down" });
            categories.Add(new Categories() { Tid = Guid.NewGuid(), CreatedAt = DateTimeOffset.UtcNow, Object = LanguageObjectConstants.Home, Priority = 2, Value = "Subtitle" });

            categories.Add(new Categories() { Tid = Guid.NewGuid(), CreatedAt = DateTimeOffset.UtcNow, Object = LanguageObjectConstants.About, Priority = 0, Value = "Subtitle" });
            categories.Add(new Categories() { Tid = Guid.NewGuid(), CreatedAt = DateTimeOffset.UtcNow, Object = LanguageObjectConstants.About, Priority = 1, Value = "Title" });
            categories.Add(new Categories() { Tid = Guid.NewGuid(), CreatedAt = DateTimeOffset.UtcNow, Object = LanguageObjectConstants.About, Priority = 2, Value = "Description" });

            categories.Add(new Categories() { Tid = Guid.NewGuid(), CreatedAt = DateTimeOffset.UtcNow, Object = LanguageObjectConstants.ServiceDetail, Priority = 0, Value = "Title" });
            categories.Add(new Categories() { Tid = Guid.NewGuid(), CreatedAt = DateTimeOffset.UtcNow, Object = LanguageObjectConstants.ServiceDetail, Priority = 1, Value = "Subtitle" });

            await context.Categories.AddRangeAsync(categories);
            await context.SaveChangesAsync();

            #endregion

            #region -- Homes --

            var homes = (from cate in categories
                         where cate.Object == LanguageObjectConstants.About
                         select new Home()
                         {
                             Tid = Guid.NewGuid(),
                             CreatedAt = DateTimeOffset.UtcNow,
                             TypeId = cate.Tid
                         });
            await context.Homes.AddRangeAsync(homes);
            await context.SaveChangesAsync();

            #endregion

            #region -- Abouts --

            var abouts = (from cate in categories
                          where cate.Object == LanguageObjectConstants.About
                          select new About()
                          {
                              Tid = Guid.NewGuid(),
                              CreatedAt = DateTimeOffset.UtcNow,
                              TypeId = cate.Tid
                          });
            await context.Abouts.AddRangeAsync(abouts);
            await context.SaveChangesAsync();

            #endregion

            #region -- Services --

            List<Service> services = new List<Service>();

            services.Add(new Service { Tid = Guid.NewGuid(), CreatedAt = DateTimeOffset.UtcNow });
            services.Add(new Service { Tid = Guid.NewGuid(), CreatedAt = DateTimeOffset.UtcNow });

            await context.Services.AddRangeAsync(services);
            await context.SaveChangesAsync();

            #endregion

            #region -- Services --

            List<ServiceDetail> serviceDetails = new List<ServiceDetail>();

            serviceDetails.Add(new ServiceDetail { Tid = Guid.NewGuid(), CreatedAt = DateTimeOffset.UtcNow, ServiceId = services[0].Tid, TypeId = categories[0].Tid });
            serviceDetails.Add(new ServiceDetail { Tid = Guid.NewGuid(), CreatedAt = DateTimeOffset.UtcNow, ServiceId = services[0].Tid, TypeId = categories[1].Tid });

            serviceDetails.Add(new ServiceDetail { Tid = Guid.NewGuid(), CreatedAt = DateTimeOffset.UtcNow, ServiceId = services[1].Tid, TypeId = categories[0].Tid });
            serviceDetails.Add(new ServiceDetail { Tid = Guid.NewGuid(), CreatedAt = DateTimeOffset.UtcNow, ServiceId = services[1].Tid, TypeId = categories[1].Tid });

            context.ServiceDetails.AddRange(serviceDetails);
            await context.SaveChangesAsync();

            #endregion

        }
    }
}
