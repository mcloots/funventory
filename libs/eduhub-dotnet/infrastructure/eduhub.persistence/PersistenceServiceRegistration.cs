using EduhubDotnet.Application.Contracts.Persistence;
using EduhubDotnet.Persistence.Repositories;
using EduhubDotnet.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EduhubDotnet.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EduHubDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("EduHubConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IProgrammeRepository, ProgrammeRepository>();

            return services;
        }
    }
}
