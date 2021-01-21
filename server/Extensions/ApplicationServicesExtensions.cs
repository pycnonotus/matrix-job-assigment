using API.Helper;
using API.Service;
using AutoMapper;
using Data;
using Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration conf)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(conf.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<ITokenService, TokenService>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddScoped<UnitOfWork>();


            return services;
        }
    }
}
