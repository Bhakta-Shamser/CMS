using Microsoft.Extensions.DependencyInjection;

namespace CMS.Contract
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddContract(this IServiceCollection services)
        {           
            return services;
        }
    }
}
