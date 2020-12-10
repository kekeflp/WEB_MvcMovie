using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_MvcMovie.Models;
using Microsoft.Data.SqlClient;

namespace WEB_MvcMovie
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
            // 安全存储应用机密
            //var builder = new SqlConnectionStringBuilder()
            //{
            //    Password = Configuration["DbPassword"]
            //};
            //var connect = builder.ConnectionString;
            //var connect = Configuration["ConnectionStrings:conStr"];

            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddDbContext<MvcMovieContext>(options => options.UseSqlServer(Configuration.GetConnectionString("conStr")));
            //services.AddDbContext<MvcMovieContext>(options => options.UseSqlServer(builder.ConnectionString));
            //services.AddDbContext<MvcMovieContext>(options => options.UseSqlServer(connect));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Movies}/{action=Index}/{id?}");
            });
        }
    }
}
