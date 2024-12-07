using CMS.Application;
using CMS.Infrastructure;
using CMS.Contract;

namespace CMS.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplication()
                .AddInfrastructure()
                .AddContract();
            
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            return services;
        }
    }
}
