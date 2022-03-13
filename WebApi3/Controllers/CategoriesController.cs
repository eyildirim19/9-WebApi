using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApi3.Models;

namespace WebApi3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        CmsProjectDBContext dBContext;
        public CategoriesController(CmsProjectDBContext context)
        {
            dBContext = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = dBContext.Categories.Select(
                c => new
                {
                    c.Name,
                    c.Description,
                    c.Id
                }).ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int Id)
        {
            var category = dBContext.Categories.Find(Id);
            var result = new
            {
                category.Name,
                category.Description,
                category.Id
            };

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            try
            {
                dBContext.Categories.Add(category);
                dBContext.SaveChanges();
                //return Ok();
                return StatusCode((int)HttpStatusCode.OK, "Kategori ekleme işlemi başarılı");
            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Üzgünüz bir hata oluştu.....!");
            }
        }

        [HttpDelete("{Id}")]
        //api/Categories/deger
        public IActionResult Delete(int Id)
        {
            try
            {
                var result = dBContext.Categories.Find(Id); // ID'ye göre ara
                if (result == null)
                {
                    //return NotFound("");
                    return StatusCode((int)HttpStatusCode.NotFound, "Silinecek obje bulunamadı!!!");
                }

                dBContext.Categories.Remove(result);

                dBContext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Hata Detayı {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult Update(Category category)
        {
            return Ok();
        }
    }
}
