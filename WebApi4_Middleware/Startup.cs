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
            //1)app.Use => en genel middleware'd�r.. kendisinden sonra gelini tetikler...
            //2)app.Run => kendisinden sonrakini tetiklemez...k�sa devre yapar ve bitirir..
            //3)app.Map => belli bir path i�in yaz�lan middleware'd�r. O parh i�erisinde use veya run kullan�l�r..
            //4app.MapWhen => request detay�na yaz�lan middlewared�r...

            //app.Map("/categories/KatList", c =>
            //{
            //    // HttpContext  =>  Request detay�na eri�mek i�in
            //    // RequestDelegate => bir sonraki middleware tetiklemek i�in

            //    app.Use(async (context, next) =>
            //    {
            //        await context.Response.WriteAsync("Buraya Gelmeye �al��t�n");
            //    });
            //});

            // short curcit (k�sa devre) kendisinden sornaki middleware tetiklemez...
            //app.Run(async (con) =>
            //{
            //    // con.Request // requestin detay�na eri�irsiniz....
            //    await con.Response.WriteAsync(" Benden sonraki middleware'ler tetiklenemez....");
            //});

            //app.Use(async (context, next) =>
            //{
            //    // dil ayarlamas� yap....
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
