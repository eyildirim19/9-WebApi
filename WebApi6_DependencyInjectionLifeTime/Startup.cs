using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi6_DependencyInjectionLifeTime.Models;

namespace WebApi6_DependencyInjectionLifeTime
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
            // burada beklenen instanceler g�nderilir. amac�m�z instance'in ya�am s�reci...

            // Dependency Injection LifeTime
            //AddSingleton => uygulama aya�a kalkt���nda tek bir instace  olu�turur...S�rekli o instance kullan�l�r
            //AddScoped    => reqeust bazl� instance olu�turur. o requestte olu�an instance ba�ka yerlerde de kullan�labilir. Yeni bir requestte yeni bir instance olu�turulur.. 
            //AddTransient =>  yeni bir instance olu�urur. S�rekli new ifadesi gibi d���nebilirsiniz...

            // NOT : Singleton ile Transiet birbirine �ok benzer...

            //services.AddSingleton<IGuidValue, GuidValue>();
            //services.AddScoped<IGuidValue, GuidValue>();
            //services.AddTransient<IGuidValue, GuidValue>();

            services.AddScoped<IGuidValue, GuidValue>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi6_DependencyInjectionLifeTime", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi6_DependencyInjectionLifeTime v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
