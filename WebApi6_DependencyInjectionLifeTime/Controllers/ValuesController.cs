using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi6_DependencyInjectionLifeTime.Models;

namespace WebApi6_DependencyInjectionLifeTime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        IGuidValue instanceService1;
        IGuidValue instanceService2;
        public ValuesController(
            IGuidValue _instacenService1,
            IGuidValue _instacenServic2
            ) // instance ctrodan set edilsin
        {
            // gelen instace value fieldımıza set edilsin...
            instanceService1 = _instacenService1;
            instanceService2 = _instacenServic2;
        }

        public IActionResult Get()
        {
            ResponseModel model = new ResponseModel();
            model.Value1 = instanceService1.Guid; // oluşan guid'i respose set et...
            model.Value2 = instanceService2.Guid;

            return Ok(model);
        }
    }
}