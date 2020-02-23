using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace AppEmpresa.UI.React.AutomapperConfig
{
    public static class AutomapperServicesExtensions
    {
        public static void AutomapperServicesAdd(this IServiceCollection services)
        {
            services.AddAutoMapper();

            RegisterMappings();
        }

        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}