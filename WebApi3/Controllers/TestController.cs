using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        List<OgrenciNot> ogrencis = new List<OgrenciNot>();

        [HttpGet]
        public IActionResult GetOgrenciList()
        {
            List<OgrenciNot> nots = new List<OgrenciNot>();
            nots.Add(new OgrenciNot { Vize = 45, Final = 56 });
            nots.Add(new OgrenciNot { Vize = 55, Final = 16 });
            nots.Add(new OgrenciNot { Vize = 45, Final = 96 });
            nots.Add(new OgrenciNot { Vize = 85, Final = 56 });
            return Ok(nots);
        }

        [HttpPost]
        public IActionResult NotHesapla(OgrenciNot ogr)
        {
            ogrencis.Add(ogr);
            return Ok();
        }
    }
}
