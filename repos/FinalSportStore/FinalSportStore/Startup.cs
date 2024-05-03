using FinalSportStore.Models;
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

namespace FinalSportStore
{
    public class Startup
    {
        private IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
         public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<StoreDbContext>(opts=>opts.UseSqlServer(Configuration["ConnectionStrings:SportStoreConnection"]));
            services.AddScoped<IStoreRepository, EFStoreRepository>();
            services.AddRazorPages();
           
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                //opts.Cookie.IsEssential = true; // make the session cookie Essential
            });
            services.AddDistributedMemoryCache();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseSession();
            app.UseStatusCodePages();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints => {
                endpoints.MapGet("/cookie", async context => {
                    int counter1 = (context.Session.GetInt32("counter1") ?? 0) + 1;
                    int counter2 = (context.Session.GetInt32("counter2") ?? 0) + 1;
                    context.Session.SetInt32("counter1", counter1);
                    context.Session.SetInt32("counter2", counter2);
                    await context.Session.CommitAsync();
                    await context.Response
                    .WriteAsync($"Counter1: {counter1}, Counter2: {counter2}");
                });

                endpoints.MapControllerRoute("catpage",
                "{category}/Page{pageNo:int}",
                new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("page", "Page{pageNo:int}",
                new { Controller = "Home", action = "Index", pageNo = 1 });

                endpoints.MapControllerRoute("category", "{category}",
                new { Controller = "Home", action = "Index", pageNo = 1 });

                endpoints.MapControllerRoute("pagination",
                "Products/Page{productPage}",
                new { Controller = "Home", action = "Index", pageNo = 1 });

                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
            SeedData.EnsurePopulated(app);
        }
    }
}
