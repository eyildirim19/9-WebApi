using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi7_DependencyInjectionOrnek.Entities;
using WebApi7_DependencyInjectionOrnek.Repository;

namespace WebApi7_DependencyInjectionOrnek.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        readonly ICategoriRepository repository;
        public CategoriesController(ICategoriRepository _repository)
        {
            repository = _repository;
        }

        [HttpGet] // list
        public IActionResult Get()
        {
            return Ok(repository.GetList());
        }

        [HttpGet("{id}")] // object
        public IActionResult Get(int id)
        {
            Category categories = repository.Get(id);
            if (categories == null)
                return NotFound("Kategori Bulunamadı");
            else
                return Ok();
        }

        [HttpPost] // create
        public IActionResult Post(Category model)
        {
            int result = repository.Add(model);
            if (result > 0)
                return Ok("Ekleme işlemi başarılı");
            else
                return BadRequest("İşlem Başarısız");
        }

        [HttpPut] // Update
        public IActionResult Put(Category model)
        {
            int result = repository.Update(model);
            if (result > 0)
                return Ok("Güncelleme işlemi başarılı");
            else
                return BadRequest("İşlem Başarısız");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Category cat = repository.Get(id);
            if(cat== null)
                return NotFound("Kategori Bulunamadı");

            int result = repository.Delete(cat);

            if (result > 0)
                return Ok("Silme İşlemi Başarılı");
            else
                return BadRequest("İşlem Başarısız");
        }
    }
}