using AutoMapper;
using PortfolioServices.Dto;
using PortfolioServices.Model;

namespace PortfolioServices.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<WeatherForecastDto, WeatherForecast>();
        CreateMap<WeatherForecast, WeatherForecastDto>();

        CreateMap<Categories, CategoriesDto>();
        CreateMap<CategoriesDto, Categories>();

        CreateMap<Home, HomeDto>();
        CreateMap<HomeDto, Home>();

        CreateMap<Language, LanguageDto>();
        CreateMap<LanguageDto, Language>();

        CreateMap<About, AboutDto>();
        CreateMap<AboutDto, About>();

        CreateMap<ServiceDetail, ServiceDetailDto>();
        CreateMap<ServiceDetailDto, ServiceDetail>();

        CreateMap<Service, ServiceDto>();
        CreateMap<ServiceDto, Service>();

        CreateMap<Client, ClientDto>();
        CreateMap<ClientDto, Client>();

        CreateMap<ClientComment, ClientCommentDto>();
        CreateMap<ClientCommentDto, ClientComment>();
    }
}