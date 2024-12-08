using CMS.Contract.Interfaces;
using CMS.Infrastructure.Persistence;
using CMS.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CMS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connString = configuration.GetConnectionString("defaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connString);
            });

            services.AddTransient<ICandidateReadRepository, CandidateRepository>();
            services.AddTransient<ICandidateRepository, CandidateRepository>();

            return services;
        }
    }
}
