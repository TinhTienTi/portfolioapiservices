using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PortfolioServices.Model;
using PortfolioServices.Utilities;
using System;

namespace PortfolioServices.Context
{
    public class SeedData
    {
        public static async Task InitializeDatabase(string connectionString)
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
                await EnsureData(ctx);
            }
        }

        private static async Task EnsureData(PortfoliServicesContext context)
        {
            List<Language> languages = new List<Language>();

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
                         }).ToList();

            await context.Homes.AddRangeAsync(homes);
            await context.SaveChangesAsync();

            languages.AddRange((from h in homes
                                from c in categories.Where(x => x.Tid == h.TypeId).DefaultIfEmpty()
                                select new Language()
                                {
                                    Tid = Guid.NewGuid(),
                                    CreatedAt = DateTimeOffset.UtcNow,
                                    Code = LanguageCodeConstants.VIET_NAM,
                                    Object = LanguageObjectConstants.Home,
                                    Key = h.Tid,
                                    Value = c.Priority == 0 ? "Xin chào!" : c.Priority == 1 ? "I am Mr.Teo" : "I am a Backend Developer"
                                }).ToList());

            languages.AddRange((from h in homes
                                from c in categories.Where(x => x.Tid == h.TypeId).DefaultIfEmpty()
                                select new Language()
                                {
                                    Tid = Guid.NewGuid(),
                                    CreatedAt = DateTimeOffset.UtcNow,
                                    Code = LanguageCodeConstants.ENGLISH,
                                    Object = LanguageObjectConstants.Home,
                                    Key = h.Tid,
                                    Value = c.Priority == 0 ? "Hi" : c.Priority == 1 ? "I am a Mr.Teo" : "I am a Backend Developer"
                                }).ToList());

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

            languages.AddRange((from h in abouts
                                from c in categories.Where(x => x.Tid == h.TypeId).DefaultIfEmpty()
                                select new Language()
                                {
                                    Tid = Guid.NewGuid(),
                                    CreatedAt = DateTimeOffset.UtcNow,
                                    Code = LanguageCodeConstants.VIET_NAM,
                                    Object = LanguageObjectConstants.About,
                                    Key = h.Tid,
                                    Value = c.Priority == 0 ? "Who Am I ?" : c.Priority == 1 ? "About Me" : "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Repudiandae aliquid ad provident aut fuga animi soluta quae eos non cupiditate voluptates dolorem, doloremque quos dicta quibusdam impedit iure nemo a iste\r\n                <br>culpa! Quasi quibusdam hic recusandae delectus velit officiis explicabo voluptatibus! Nemo esse similique, voluptates labore distinctio, placeat explicabo facilis molestias, blanditiis culpa iusto voluptatem ratione eligendi a, quia temporibus velit vero ipsa sint ex voluptatum expedita aliquid! Debitis, nam!"
                                }).ToList());

            languages.AddRange((from h in abouts
                                from c in categories.Where(x => x.Tid == h.TypeId).DefaultIfEmpty()
                                select new Language()
                                {
                                    Tid = Guid.NewGuid(),
                                    CreatedAt = DateTimeOffset.UtcNow,
                                    Code = LanguageCodeConstants.ENGLISH,
                                    Object = LanguageObjectConstants.About,
                                    Key = h.Tid,
                                    Value = c.Priority == 0 ? "Who Am I ?" : c.Priority == 1 ? "About Me" : "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Repudiandae aliquid ad provident aut fuga animi soluta quae eos non cupiditate voluptates dolorem, doloremque quos dicta quibusdam impedit iure nemo a iste\r\n                <br>culpa! Quasi quibusdam hic recusandae delectus velit officiis explicabo voluptatibus! Nemo esse similique, voluptates labore distinctio, placeat explicabo facilis molestias, blanditiis culpa iusto voluptatem ratione eligendi a, quia temporibus velit vero ipsa sint ex voluptatum expedita aliquid! Debitis, nam!"
                                }).ToList());

            #endregion

            #region -- Services --

            List<Service> services = new List<Service>();

            services.Add(new Service { Tid = Guid.NewGuid(), CreatedAt = DateTimeOffset.UtcNow });
            services.Add(new Service { Tid = Guid.NewGuid(), CreatedAt = DateTimeOffset.UtcNow });

            await context.Services.AddRangeAsync(services);
            await context.SaveChangesAsync();

            languages.AddRange((from h in services
                                select new Language()
                                {
                                    Tid = Guid.NewGuid(),
                                    CreatedAt = DateTimeOffset.UtcNow,
                                    Code = LanguageCodeConstants.VIET_NAM,
                                    Object = LanguageObjectConstants.Service,
                                    Key = h.Tid,
                                    Value = "Placeat"
                                }).ToList());

            languages.AddRange((from h in services

                                select new Language()
                                {
                                    Tid = Guid.NewGuid(),
                                    CreatedAt = DateTimeOffset.UtcNow,
                                    Code = LanguageCodeConstants.ENGLISH,
                                    Object = LanguageObjectConstants.Service,
                                    Key = h.Tid,
                                    Value = "Placeat"
                                }).ToList());

            languages.AddRange((from h in services
                                select new Language()
                                {
                                    Tid = Guid.NewGuid(),
                                    CreatedAt = DateTimeOffset.UtcNow,
                                    Code = LanguageCodeConstants.VIET_NAM,
                                    Object = LanguageObjectConstants.Service,
                                    Key = h.Tid,
                                    Value = "Iusto"
                                }).ToList());

            languages.AddRange((from h in services

                                select new Language()
                                {
                                    Tid = Guid.NewGuid(),
                                    CreatedAt = DateTimeOffset.UtcNow,
                                    Code = LanguageCodeConstants.ENGLISH,
                                    Object = LanguageObjectConstants.Service,
                                    Key = h.Tid,
                                    Value = "Iusto"
                                }).ToList());

            #endregion

            #region -- Services --

            List<ServiceDetail> serviceDetails = new List<ServiceDetail>();

            serviceDetails.Add(new ServiceDetail { Tid = Guid.NewGuid(), CreatedAt = DateTimeOffset.UtcNow, ServiceId = services[0].Tid, TypeId = categories[0].Tid });
            serviceDetails.Add(new ServiceDetail { Tid = Guid.NewGuid(), CreatedAt = DateTimeOffset.UtcNow, ServiceId = services[0].Tid, TypeId = categories[1].Tid });

            serviceDetails.Add(new ServiceDetail { Tid = Guid.NewGuid(), CreatedAt = DateTimeOffset.UtcNow, ServiceId = services[1].Tid, TypeId = categories[0].Tid });
            serviceDetails.Add(new ServiceDetail { Tid = Guid.NewGuid(), CreatedAt = DateTimeOffset.UtcNow, ServiceId = services[1].Tid, TypeId = categories[1].Tid });

            context.ServiceDetails.AddRange(serviceDetails);
            await context.SaveChangesAsync();

            languages.AddRange((from h in serviceDetails
                                from s in services.Where(x => x.Tid == h.ServiceId).DefaultIfEmpty()
                                from c in categories.Where(x => x.Tid == h.TypeId).DefaultIfEmpty()
                                select new Language()
                                {
                                    Tid = Guid.NewGuid(),
                                    CreatedAt = DateTimeOffset.UtcNow,
                                    Code = LanguageCodeConstants.VIET_NAM,
                                    Object = LanguageObjectConstants.ServiceDetail,
                                    Key = h.Tid,
                                    Value = h.TypeId == c.Tid  ? "Placeat" : h.TypeId == c.Tid ? "Iusto" : "Labore velit culpa adipisci excepturi consequuntur itaque in nam molestias dolorem iste quod." 
                                }).ToList());

            languages.AddRange((from h in serviceDetails
                                from c in categories.Where(x => x.Tid == h.TypeId).DefaultIfEmpty()
                                select new Language()
                                {
                                    Tid = Guid.NewGuid(),
                                    CreatedAt = DateTimeOffset.UtcNow,
                                    Code = LanguageCodeConstants.ENGLISH,
                                    Object = LanguageObjectConstants.ServiceDetail,
                                    Key = h.Tid,
                                    Value = h.TypeId == c.Tid ? "Placeat" : h.TypeId == c.Tid ? "Iusto" : "Labore velit culpa adipisci excepturi consequuntur itaque in nam molestias dolorem iste quod."
                                }).ToList());

            #endregion

            await context.Languages.AddRangeAsync(languages);
            context.SaveChanges();

        }
    }
}
