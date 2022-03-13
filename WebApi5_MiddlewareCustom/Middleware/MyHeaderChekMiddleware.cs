using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi5_MiddlewareCustom.Middleware
{
    public class MyHeaderChekMiddleware
    {
        RequestDelegate _next;
        public MyHeaderChekMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //if (context.Request.Path == "blabla")
            //{
            //    await _next(context);
            //}
            //else
            //{
            //}

            string path = context.Request.Path;
            string token = context.Request.Headers["clientkimlikno"];
            if (token != null)
            {
                await _next(context); // bir sonraki middlera geç...
            }
            else // süreci bitiriyoruz...
            {
                context.Response.StatusCode = 400; // authorhorize kodu dönelim...
                await context.Response.WriteAsync("Servise erişme yetkiniz yok!!!!.Lütfen bizimle iletişime geçerek servis kimliği isteyin veya requestiniz headerına kimliknumaranızı ekleyin");
            }
        }
    }
}
