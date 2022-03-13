using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi5_MiddlewareCustom.Middleware
{
    public class MyMiddleware
    {
        // custom middleware'iimizi tetiklenmesi için  bir önceki middleware tarafında Invoke isminde bir metot yazılır...Eğer Metot ismi Invoke olarak belirtilmezse bir önceki middlewre bizim middlewaremizi handle (tetiklemek) edemez.

        // 1 önceki middleware'in bizim middlewreimizi tetiklemesi 
        // 2 pipelinedaki middlewarein tetiklenmesi


        RequestDelegate _next; // bir sonraki middeware tetiklenmesi için....
        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        // HttpContext => request'e erişmek için kullanılır...
        public async Task Invoke(HttpContext context)
        {
            string path = context.Request.Path; // Requestin pathi;
            string tppe = context.Request.Method; // request metot Type


            await _next(context); // pipeline'daki middlere tetikle...
        }
    }

}
