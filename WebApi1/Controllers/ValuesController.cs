using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1.Controllers
{
    // Route => api/controller => şeklinde çağrılabilir...
    // http://localhost:portNo/api/values şeklinde öğrenci listesine erişilebilir...
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET => veri okumak
        // POST => veri eklemek
        // PUT => veri güncellemek
        // DELETE => veri silmek

        // VERİ
        List<string> ogrenciler = new List<string>() { "BAHAR", "SEMİHA", "SUNA", "ÖNDER", "SERHAT", "FURKAN" };

        // URI
        //[HttpGet] // default http request type her zaman gettir...
        public IActionResult Get()
        {
            return Ok(ogrenciler);
            // işlemler yapıldı
        }

        // Sadece post requestlerde erişilebilir
        [HttpPost]
        public IActionResult Post()
        {
            return Ok(true);
        }
    }
}