using System.Text;
using Core.Entities;
using Infrastructure.Database.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Application.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            // Skinet-main
            // var builder = services.AddIdentityCore<Customer>();
            // builder = new IdentityBuilder(builder.UserType, builder.Services);
            // builder.AddEntityFrameworkStores<AppIdentityDbContext>();
            // builder.AddSignInManager<SignInManager<Customer>>();

            services.AddIdentity<Customer, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                var secretByte = Encoding.UTF8.GetBytes(config["Authentication:SecretKey"]);
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = config["Authentication:Issuer"],

                    ValidateAudience = true,
                    ValidAudience = config["Authentication:Audience"],

                    ValidateLifetime = true,

                    IssuerSigningKey = new SymmetricSecurityKey(secretByte)
                };
            });
            return services;
        }
    }
}