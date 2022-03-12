using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OgrenciController : ControllerBase
    {
        List<Ogrenci> ogrenciler = new List<Ogrenci>();
        public OgrenciController()
        {
            ogrenciler.Add(new Ogrenci { Adi = "Serhat", Cinsiyet = "Bay", Yas = 20 });
            ogrenciler.Add(new Ogrenci { Adi = "Önder", Cinsiyet = "Bay", Yas = 40 });
            ogrenciler.Add(new Ogrenci { Adi = "Bahar", Cinsiyet = "Bayan", Yas = 20 });
            ogrenciler.Add(new Ogrenci { Adi = "Semiha", Cinsiyet = "Bayan", Yas = 20 });
            ogrenciler.Add(new Ogrenci { Adi = "Suna", Cinsiyet = "Bayan", Yas = 20 });
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ogrenciler);
        }

        [HttpGet("{cinsiyet}")] // parametre tanımlıyoruz...
        public IActionResult Get(string cinsiyet)
        {
            return Ok(ogrenciler.Where(c => c.Cinsiyet == cinsiyet).ToList());
        }

        [HttpPost]
        public IActionResult Post(Ogrenci ogr)
        {
            ogrenciler.Add(ogr);
            return Ok("İşlem Başarılı");
        }
    }
}
