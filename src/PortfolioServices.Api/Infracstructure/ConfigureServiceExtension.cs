using PortfolioServices.Api.Bo;
using PortfolioServices.Api.Bo.Interfaces;
using PortfolioServices.Context;
using PortfolioServices.Dto;
using PortfolioServices.Model;
using PortfolioServices.Repositories;
using PortfolioServices.Repositories.Interfaces;

namespace PortfolioServices.Api.Infracstructure
{
    public static class ConfigureServiceExtension
    {
        public static void AddConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContexts();

            services.AddRepositories();

            services.AddBo();

            services.AddProfiles();

            services.AddApplicationControllers();

            services.AddSwagger();
        }

        private static void AddDbContexts(this IServiceCollection services)
        {
            services.AddDbContext<PortfoliServicesContext>();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<Home, HomeDto>, GenericRepository<Home, HomeDto>>();
            services.AddScoped<IGenericRepository<Language, LanguageDto>, GenericRepository<Language, LanguageDto>>();
            services.AddScoped<IGenericRepository<Categories, CategoriesDto>, GenericRepository<Categories, CategoriesDto>>();
        }

        private static void AddBo(this IServiceCollection services)
        {
            services.AddScoped<IHomeBo, HomeBo>();
            services.AddScoped<ILanguageBo, LanguageBo>();
            services.AddScoped<ICategoryBo, CategoryBo>();

            services.AddScoped<IProfileBo, ProfileBo>();
        }

        private static void AddProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(PortfolioServices.Profiles.MappingProfile));
        }

        private static void AddApplicationControllers(this IServiceCollection services)
        {
            services.AddControllers();
        }

        private static void AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();
        }
    }
}
