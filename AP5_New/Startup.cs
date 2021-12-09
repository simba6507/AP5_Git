using AP5_New.Models;
using AP5_New.Services.IServices;
using AP5_New.Services.ServiceImplement;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AP5_New
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
            services.AddSingleton<ICodeService, CodeService>();
            services.AddSingleton<IModuleService, ModuleService>();
            services.AddSingleton<IContainerService, ContainerService>();
            services.AddSingleton(Log.Logger);
            services.AddControllersWithViews();
            services.AddDbContext<AP5_NewContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("AP5_NewConn"))
                .UseLoggerFactory(LoggerFactory.Create(builder => {
                    builder.AddSerilog();
                }));
                options.EnableSensitiveDataLogging();
            });               
            services.AddDbContext<CL_COUNTERDBContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("CL_PICSConn"));
                options.EnableSensitiveDataLogging();
            });
            services.AddDbContext<KN_COUNTERDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("KN_PICSConn"));
                options.EnableSensitiveDataLogging();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
