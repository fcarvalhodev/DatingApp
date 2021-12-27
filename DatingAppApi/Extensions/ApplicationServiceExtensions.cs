using DatingAppApi.Data;
using DatingAppApi.Interfaces;
using DatingAppApi.Services;
using Microsoft.EntityFrameworkCore;

namespace DatingAppApi.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();

            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
        
    }
}
