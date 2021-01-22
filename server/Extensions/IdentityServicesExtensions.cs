using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Extensions
{
    public static class IdentityServicesExtensions
    {

        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {

            services.AddIdentityCore<AppUser>(
                opt =>
                {
                    opt.Password.RequireNonAlphanumeric = true;
                    opt.Password.RequireDigit = true;
                    opt.Password.RequireLowercase = true;
                    opt.Password.RequireUppercase = true;
                    // there is no real reason for the previous lines , but for the sake of the assignment 
                    // for staffing the requirements of the password strength ( these are the defaults)
                    opt.Password.RequiredLength = 8;
                }
            )
            .AddEntityFrameworkStores<DataContext>()
                        .AddSignInManager<SignInManager<AppUser>>()

            ;
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(
                                    config["TokenKey"]
                                )
                            ),
                        ValidateIssuer = false,
                        ValidateAudience = false

                    };

                }
                );
            return services;
        }

    }
}
