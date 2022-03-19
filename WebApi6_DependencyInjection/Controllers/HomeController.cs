using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi6_DependencyInjection.Models;

namespace WebApi6_DependencyInjection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        // readonly => sadece ilgisi sınıfının constructorinda değer atamak için kullanılır
        readonly IMailManage manage;
        public HomeController(IMailManage _manage)
        {
            //  dependency injection( bağımlılıkları enjekte edebilmek) için çeşitli IoC Container kütüphaneler kullanılır. Bu kütüphaneler;
            //Ninject,AutoFac,Unity,Spring.NET 
            // .net core'da ioc container için ekstra yukarıdaki gibi kütüphanele kullanılmaz. Bu yapı buid-in gelmektedir..Dependency Injection .net core'in önemli yapılarından biridir..Bağımlıkları enjecte edebilmek için startup dosyasının ConfigureService metodu vardır. Bu metttan controllerların bekledikleri bağımlılıklar enjekte edilir...
            manage = _manage;
        }

        public IActionResult Index()
        {
            return Ok(true);
        }
    }
}