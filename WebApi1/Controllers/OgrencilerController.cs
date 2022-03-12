using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1.Controllers
{
    [Route("api/[controller]/[action]")]
    // http://localhost:portno/ogrenciler/actionName
    [ApiController]
    public class OgrencilerController : ControllerBase
    {
        List<string> ogrenciler = new List<string>() { "BAHAR", "SEMİHA", "SUNA", "ÖNDER", "SERHAT", "FURKAN" };

        public IActionResult Get1()
        {
            return Ok(ogrenciler); // HttpStatusCode 200 anlamına gelir...
        }

        public IActionResult List()
        {
            return NotFound("Üzgünüz veriyi bulamadık...."); // httpstatuscode 404 anlamanına gelir..
        }
    }
}
