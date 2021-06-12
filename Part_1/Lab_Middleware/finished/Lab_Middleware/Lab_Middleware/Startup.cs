using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_Middleware {
    public class Startup {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
        }


        private static void HandleMap1(IApplicationBuilder app) {
            app.Run(async context => {
                await context.Response.WriteAsync("Map One");
            });
        }

        private static void HandleMap2(IApplicationBuilder app) {
            app.Run(async context => {
                await context.Response.WriteAsync("Map Two");
            });
        }

        public void Configure(IApplicationBuilder app) {
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.Map("/map1", HandleMap1);
            app.Map("/map2", HandleMap2);
            app.Run(async context => {
                await context.Response.WriteAsync("Other delegate. Hint: type /map1 for testing");
            });
        }

        // -------------------------------------

        //public void Configure(IApplicationBuilder app)
        //{
        //    app.Use(async (context, next) =>
        //    {
        //        context.Response.ContentType = "text/html";
        //        await context.Response.WriteAsync("Hello from first delegate.<br>");
        //        await next.Invoke();
        //        await context.Response.WriteAsync("code from first delegate. ( after invoke() )<br>");
        //    });

        //    app.Use(async (context, next) =>
        //    {
        //        await context.Response.WriteAsync("Hello from second delegate.<br>");
        //        await next.Invoke();
        //    });

        //    app.Run(async context =>
        //    {
        //        await context.Response.WriteAsync("Hello from final delegate.<br>");
        //    });
        //}

        // -------------------------------------------

        //public void Configure(IApplicationBuilder app)
        //{
        //    app.Run(async context =>
        //    {
        //        await context.Response.WriteAsync("Hello, ASP.NET Core!");
        //    });
        //}


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }

        //    app.UseRouting();

        //    app.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapGet("/", async context =>
        //        {
        //            await context.Response.WriteAsync("Hello World!");
        //        });
        //    });
        //}
    }
}
