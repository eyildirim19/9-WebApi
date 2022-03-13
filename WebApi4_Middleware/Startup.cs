using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi4_Middleware
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

            //CustomMiddleware
            //1)app.Use => en genel middleware'dýr.. kendisinden sonra gelini tetikler...
            //2)app.Run => kendisinden sonrakini tetiklemez...kýsa devre yapar ve bitirir..
            //3)app.Map => belli bir path için yazýlan middleware'dýr. O parh içerisinde use veya run kullanýlýr..
            //4app.MapWhen => request detayýna yazýlan middlewaredýr...

            //app.Map("/categories/KatList", c =>
            //{
            //    // HttpContext  =>  Request detayýna eriþmek için
            //    // RequestDelegate => bir sonraki middleware tetiklemek için

            //    app.Use(async (context, next) =>
            //    {
            //        await context.Response.WriteAsync("Buraya Gelmeye çalýþtýn");
            //    });
            //});

            // short curcit (kýsa devre) kendisinden sornaki middleware tetiklemez...
            //app.Run(async (con) =>
            //{
            //    // con.Request // requestin detayýna eriþirsiniz....
            //    await con.Response.WriteAsync(" Benden sonraki middleware'ler tetiklenemez....");
            //});

            //app.Use(async (context, next) =>
            //{
            //    // dil ayarlamasý yap....
            //    CultureInfo culture = new CultureInfo("tr-TR");
            //    CultureInfo.CurrentCulture = culture;
            //    CultureInfo.CurrentUICulture = culture;
            //    //await context.Response.WriteAsync("Before Invoke from 1st app.Use()\n");
            //    await next();
            //});

            app.UseRouting(); // middleware

            app.UseAuthorization(); // middleware

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });






        }
    }
}
