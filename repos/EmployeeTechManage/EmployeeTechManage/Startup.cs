using EmployeeTechManage.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTechManage
{
    public class Startup
    {
        public IConfiguration configuration { get; }

        public Startup(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("EmployeeConnection")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("TypeDept","{dept}/Page{empPage:int}", new { Controller = "Home", action = "EmployeeList" });
                endpoints.MapControllerRoute("Page", "Page{empPage:int}", new { Controller = "Home", action = "EmployeeList",empPage=1 });
                endpoints.MapControllerRoute("DeptName","{dept}", new { Controller = "Home", action = "EmployeeList", empPage = 1 });

                endpoints.MapControllerRoute("DepartPage", "{dept}", new { Controller = "Home", action = "EmployeeList", empPage = 1 });
                endpoints.MapControllerRoute("Depart", "Department/Page{empPage}", new { Controller = "Home", action = "EmployeeList", empPage = 1 });

                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
