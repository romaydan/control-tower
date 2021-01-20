using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlTower.BL.Api;
using ControlTower.BL.Services;
using ControlTower.DAL;
using ControlTower.DAL.Api;
using ControlTower.DAL.Repositories;
using ControlTower.Generator;
using ControlTower.Server.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ControlTower.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {

                options.AddPolicy("CorsPolicy", builder => builder
                .WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            });
            services.AddSignalR();
            //services.AddDbContext<AirportContext>(ServiceLifetime.Transient);
            services.AddTransient<ILandingsRepository, LandingsRepository>();
            services.AddTransient<ILogRepository, LogRepository>();
            services.AddTransient<IStateRepository, StateRepository>();

            services.AddTransient<ISystemSnapshot, SystemSnapshot>();
            services.AddTransient<ILogService, LogService>();
            services.AddTransient<IAirportBuilder, AirportBuilder>();

            services.AddSingleton<IAirportMediator, AirportMediator>();
            services.AddSingleton<IAirportState, AirportState>();
            services.AddSingleton<IPlaneGenerator, PlaneGenerator>();
            services.AddSingleton<INotificationService, NotificationService>();
            services.AddSingleton<AirportHub>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors("CorsPolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<AirportHub>(@"/hub");

            });
        }
    }
}
