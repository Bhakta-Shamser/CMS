using CMS.Application;
using CMS.Infrastructure;
using CMS.Contract;
using CMS.Contract.Interfaces;
using CMS.Infrastructure.Services;

namespace CMS.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplication()
                .AddInfrastructure(configuration)
                .AddContract();
            
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddSingleton<ISqlConnectionFactory>(provider => new SqlConnectionFactory(configuration.GetConnectionString("defaultConnection")));

            return services;
        }
    }
}
