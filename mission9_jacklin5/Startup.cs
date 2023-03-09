using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using mission9_jacklin5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_jacklin5
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.

        public IConfiguration Configuration { get; set; }
        public Startup (IConfiguration temp)
        {
            Configuration = temp;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<BookstoreContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:BookstoreDBConnection"]);    //Allows us to use sqlite database
            });

            services.AddScoped<IBookstoreRepository, EFBookStoreRepository>();

            services.AddRazorPages();
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();

            app.UseEndpoints(endpoints =>           //Use endpoints to clean up url and direct people where they need to go
            {                                   
                
                endpoints.MapControllerRoute("typepage", "{bookCategory}/Page{pageNum}", new { Controller = "Home", action = "Index" });    //If we are passed a bookcategory and a page num

                endpoints.MapControllerRoute(           //If we're just passed a pagenu
                   name: "Paging",
                   pattern: "Page{pageNum}",
                   defaults: new { Controller = "Home", action = "Index", pageNum=1 });

                endpoints.MapControllerRoute("type", "{bookCategory}", new { Controller = "Home", action = "Index", pageNum=1 });   //If we're passed only a category

                endpoints.MapDefaultControllerRoute();          //Easier way to do MVC routing

                endpoints.MapRazorPages();
            });

            
        }
    }
}
