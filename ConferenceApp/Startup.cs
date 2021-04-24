using System.Reflection;
using ConferenceApp.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DNTCaptcha.Core;
using MediatR;

namespace ConferenceApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        private readonly IConfiguration _config;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPersistence(_config);

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddDNTCaptcha(options =>
                options.UseCookieStorageProvider().ShowThousandsSeparators(false));

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });
        }
    }
}