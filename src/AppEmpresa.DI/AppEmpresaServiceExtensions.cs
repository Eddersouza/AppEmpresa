using AppEmpresa.App.Services;
using AppEmpresa.Data.NHibernate.Repositories;
using AppEmpresa.Data.NHibernate.Repositories.Base;
using AppEmpresa.Domain.Contracts.Apps;
using AppEmpresa.Domain.Contracts.Repositories;
using AppEmpresa.Domain.Contracts.Repositories.Base;
using AppEmpresa.Domain.Contracts.Services;
using AppEmpresa.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AppEmpresa.DI
{
    public static class AppEmpresaServiceExtensions
    {
        public static IServiceCollection ConfigureAppEmpresaServices(
           this IServiceCollection services)
        {
            services.AddScoped<CompanyServiceContract, CompanyService>();
            return services;
        }

        public static IServiceCollection ConfigureAppEmpresaServicesApp(
                    this IServiceCollection services)
        {
            services.AddScoped<CompanyAppContract, CompanyApp>();
            return services;
        }

        public static IServiceCollection ConfigureAppEmpresaServicesRepositories(
            this IServiceCollection services)
        {
            services.AddScoped<UnityOfWorkContract, UnityOfWork>();
            services.AddScoped<CompanyRepositoryContract, CompanyRepository>();
            services.AddScoped(typeof(BaseRepositoryContract<>), typeof(BaseRepository<>));

            return services;
        }
    }
}