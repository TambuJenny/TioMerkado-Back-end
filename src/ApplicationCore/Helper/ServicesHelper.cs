using AutoMapper;

namespace AplicationCore.Helpers
{
    public class ServicesHelper
    {
        public static void RegisterBusinesses(IServiceCollection services)
        {
           

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