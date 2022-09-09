using ApplicationCore.Services;
using AutoMapper;
using DomaineService.Models.Request.Product;
using DomaineService.Models.Response.Product;
using DomainService.Interface.Product;
using DomainService.Models.Product;

namespace AplicationCore.Helpers
{
    public class ServicesHelper
    {
        public static void RegisterBusinesses(IServiceCollection services)
        {
            services.AddScoped<PCInterface, PcServices>();

            //AutoMapper
            var mapperConfig = new MapperConfiguration(conf =>
            {
                conf.CreateMap<PCModel, PCRequest>().ReverseMap();
                conf.CreateMap<PCModel, PcResponse>().ReverseMap();
            });
            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
