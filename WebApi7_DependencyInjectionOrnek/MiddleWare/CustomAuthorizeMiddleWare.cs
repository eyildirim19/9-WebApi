using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi7_DependencyInjectionOrnek.MiddleWare
{
    public class CustomAuthorizeMiddleWare
    {
        readonly RequestDelegate delege;
        public CustomAuthorizeMiddleWare(RequestDelegate _delege)
        {
            delege = _delege;
        }

        public async Task Invoke(HttpContext context)
        {
            string token = context.Request.Headers["token"];
            if (token != null)
            {
                await delege(context); // sonrakine geç....
            }
            else
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Servise erişim yetkiniz bulunmamakta");
            }
        }
    }
}
