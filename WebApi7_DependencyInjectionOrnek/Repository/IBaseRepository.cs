using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi7_DependencyInjectionOrnek.Repository
{
    public interface IBaseRepository<T>
    {
        List<T> GetList();
        T Get(int id);
        int Add(T item);
        int Update(T item);
        int Delete(T item);
    }

}
