using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi5_MiddlewareCustom.Middleware;

namespace WebApi5_MiddlewareCustom.Extensions
{
    public static class MyMiddlewareExtensions
    {

        // this o anki instace.. Bu metot artık stringin extension metodudur..
        public static int IntYap(this string value)
        {
            return int.Parse(value);
        }


        public static IApplicationBuilder UseMyMiddleWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddleware>();
        }

        public static async Task<IApplicationBuilder> UseHeaderCheckMiddleWare(this IApplicationBuilder builder)
        {
           return builder.UseMiddleware<MyHeaderChekMiddleware>();
        }

    }
}
