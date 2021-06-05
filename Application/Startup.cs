using System;
using System.Text;
using Application.Middlewares;
using Infrastructure.Database.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Infrastructure.Database.Identity;
using Core.Entities;
using Application.Extensions;
using AutoMapper;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using API.Extensions;

namespace Application
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityServices(_config);

            services.AddControllers().AddNewtonsoftJson(options => {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            
            services.AddDbContext<AppDbContext>(
                option =>
                {
                    option.UseSqlServer(_config["ConnectionStrings:Default"]);
                }
            );
            services.AddDbContext<AppIdentityDbContext>(
                option =>
                {
                    option.UseSqlServer(_config["ConnectionStrings:Identity"]);
                }
            );
            services.AddSwaggerDocumentation();
            services.AddHttpContextAccessor();

            services.AddApplicationServices();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // 錯誤處理的中間介
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseSwaggerDocumentation();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
