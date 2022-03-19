using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi7_DependencyInjectionOrnek.Entities;

namespace WebApi7_DependencyInjectionOrnek.Repository
{
    public class CategoriRepository : ICategoriRepository
    {
        CmsProjectDBContext context;
        public CategoriRepository(CmsProjectDBContext _context)
        {
            context = _context;
        }

        public int Add(Category item)
        {
            context.Categories.Add(item);

            try
            {
                return context.SaveChanges();
            }
            catch
            {
                return -1;
            }

        }

        public int Delete(Category item)
        {
            context.Categories.Remove(item);
            try
            {
                return context.SaveChanges();
            }
            catch
            {
                return -1;
            }
        }

        public Category Get(int id)
        {
            return context.Categories.Find(id);
        }

        public List<Category> GetList()
        {
            return context.Categories.ToList();
        }

        public int Update(Category item)
        {
            try
            {
                // tek tek değer set etmek yerine, değerleri karşılaştır gücnellenenleri set...
                context.Entry<Category>(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return context.SaveChanges();
            }
            catch
            {
                return -1;
            }
        }
    }
}
