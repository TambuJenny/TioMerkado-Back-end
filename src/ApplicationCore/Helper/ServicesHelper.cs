using AplicationCore.Services;
using AutoMapper;
using DomainService.Interfaces;

namespace AplicationCore.Helpers
{
    public class ServicesHelper
    {
        public static void RegisterBusinesses(IServiceCollection services)
        {
           
           services.AddScoped<IUsuarios,UsuarioServices>();

            //AutoMapper
            var mapperConfig = new MapperConfiguration(
                conf =>
                {
                   
                }
            );
            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}