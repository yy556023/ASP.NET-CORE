using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_Middleware
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        private static void HandleMap1(IApplicationBuilder app)
        {
            app.Run(async context => {
                await context.Response.WriteAsync("Map One");
            });
        }

        private static void HandleMap2(IApplicationBuilder app)
        {
            app.Run(async context => {
                await context.Response.WriteAsync("Map Two");
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.Map("/map1", HandleMap1);
            app.Map("/map2", HandleMap2);
            app.Run(async context => {
                await context.Response.WriteAsync("Other delegate. Hint: type /map1 for testing");
            });
        }
    }
}
