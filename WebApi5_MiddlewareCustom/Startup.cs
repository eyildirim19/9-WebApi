using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi5_MiddlewareCustom.Extensions;
using WebApi5_MiddlewareCustom.Middleware;

namespace WebApi5_MiddlewareCustom
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

            services.AddControllers();
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

            //app.Map("/weatherforecast", conf =>
            //{
            //    //app.UseMiddleware<MyHeaderChekMiddleware>();
            //    conf.UseMiddleware<MyHeaderChekMiddleware>();
            //});
            //app.UseMiddleware<MyHeaderChekMiddleware>();
            //Custom Middleware bur
            // app.UseMiddleware<MyMiddleware>();  // Bir önceki Invoke metodumuzu tetikleyip. bizim ýnvoke metodumuzda bir sonraki middleware tetikleyecek...

            app.UseMyMiddleWare();
            app.UseHeaderCheckMiddleWare();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
