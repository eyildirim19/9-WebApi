using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi5_MiddlewareCustom.Extensions;

namespace WebApi5_MiddlewareCustom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        string[] ogrenciler = { "Semiha", "Suna", "Bahar", "Önder", "Serhat", "Furkan" };
        
        [HttpGet]
        public IActionResult Get()
        {
            string str="123";

            // extension metot...Extension metot c# içerisindeki varlıklarımıza uzantı metot yapmamızı sağlar...
            //int a = MyMiddlewareExtensions.IntYap(str);
            int b = str.IntYap();


            return Ok(ogrenciler);
        }
    }
}
