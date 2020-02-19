using AppEmpresa.Data.NHibernate.Maps;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppEmpresa.DI
{
    public static class HibernateConfigurationExtension
    {
        public static IServiceCollection ConfigureHibernate(
           this IServiceCollection services,
            IConfiguration configuration)
        {

            var connStr = configuration.GetConnectionString("connectionEmpresa");
            var _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connStr))
                .Mappings(m => m.FluentMappings.AddFromAssembly(typeof(ComapanyMap).Assembly))
                .BuildSessionFactory();

            services.AddScoped(factory =>
            {
                return _sessionFactory.OpenSession();
            });

            return services;
        }
    }
}