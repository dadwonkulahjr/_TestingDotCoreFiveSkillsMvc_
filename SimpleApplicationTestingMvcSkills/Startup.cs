using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleApplicationTestingMvcSkills.Models;
using System.Data.Common;

namespace SimpleApplicationTestingMvcSkills
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddXmlSerializerFormatters();
            services.Configure<RouteOptions>((_routeOptions) =>
            {
                _routeOptions.AppendTrailingSlash = true;
                _routeOptions.LowercaseQueryStrings = true;
                _routeOptions.LowercaseUrls = true;
            });
            services.AddIdentity<IdentityUser, IdentityRole>((options) =>
            {

            }).AddEntityFrameworkStores<AppDbContext>();
            services.AddDbContext<AppDbContext>((options) =>
            {
                options.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IEmployeeRepo, SQLDbRepository>();
           
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseDefaultFiles();
           
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints((_configEndPoints) =>
            {
                _configEndPoints.MapControllerRoute(
                    "default",
                    "{controller=Welcome}/{action=Programming}/{id?}"
                    );
            });



            //app.Run(async _context =>
            //{
            //    await _context.Response.WriteAsync("Last response!!!!");
            //});
          
        }
    }
}
