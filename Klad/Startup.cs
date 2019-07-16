using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Klad.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Klad
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
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});


            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ProductContext>(options => options.UseSqlServer(connection));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //    "Default", // Route name
                //    new { controller = "Home", action = "Index" } // Parameter defaults
                //    );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Main}/{id?}");

                //routes.MapRoute(null,
                //                "",
                //                new
                //                {
                //                    controller = "Home",
                //                    action = "Index",
                //                    category = (string)null,
                //                    page = 1
                //                }
                //            );

                //routes.MapRoute(
                //    name: null,
                //    url
                //    defaults: new { controller = "Home", action = "Index", category = (string)null },
                //    constraints: new { page = @"\d+" }
                //);

                //routes.MapRoute(null,
                //"{category}",
                //new { controller = "Home", action = "Index", page = 1 });

                routes.MapRoute(null,
                "{category}",
                new { controller = "Home", action = "Index" });


                //routes.MapRoute(null,
                //    "{category}/Page{page}",
                //    new { controller = "Home", action = "Index" },
                //    new { page = @"\d+" }
                //);

                routes.MapRoute(null,
               "{category}/{page}",
               new { controller = "Home", action = "Index" }
               //,
               //new { page = @"\d+" }
               );


                // routes.MapRoute(null,
                //  "{category}/{page}/{product}",
                //  new { controller = "Home", action = "ViewProduct" },
                //  new { page = @"\d+" }
                //  );

                //   routes.MapRoute(null,
                //"{category}/{page}/{product}",
                //new { controller = "Home", action = "ViewProduct" },
                //new { page = @"\d+" },
                //new { page = @"\d+" }
                //);

            });
        }
    }
}
