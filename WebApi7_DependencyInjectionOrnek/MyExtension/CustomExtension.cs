using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi7_DependencyInjectionOrnek.MiddleWare;

namespace WebApi7_DependencyInjectionOrnek.MyExtension
{
    public static class CustomExtension
    {
        public static IApplicationBuilder UseCustomAuthorize(this IApplicationBuilder build)
        {
            return build.UseMiddleware<CustomAuthorizeMiddleWare>();
        }
    }
}