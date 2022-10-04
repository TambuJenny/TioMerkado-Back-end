using ApplicationCore.Services;
using ApplicationCore.Services.Product;
using AutoMapper;
using DomaineService.Models.Request.Product;
using DomaineService.Models.Response.Product;
using DomainService.Interface;
using DomainService.Interface.Product;
using DomainService.Models;
using DomainService.Models.Product;
using DomainService.Models.Request;

namespace AplicationCore.Helpers
{
    public class ServicesHelper
    {
        public static void RegisterBusinesses(IServiceCollection services)
        {
            services.AddScoped<PCInterface, PcServices>();
            services.AddScoped<BrandInterface, BrandServices>();
            services.AddScoped<UserInterface, UserServices>();

            //AutoMapper
            var mapperConfig = new MapperConfiguration(conf =>
            {
                conf.CreateMap<PCModel, PCRequest>().ReverseMap();
                conf.CreateMap<PCModel, PcResponse>().ReverseMap();
                conf.CreateMap<BrandModel, BrandResponse>().ReverseMap();
                conf.CreateMap<BrandModel, BrandRequest>().ReverseMap();
                conf.CreateMap<UserModel, UserRequest>().ReverseMap();
            });
            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
