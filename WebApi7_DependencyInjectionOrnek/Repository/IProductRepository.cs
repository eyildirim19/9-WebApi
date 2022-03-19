using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi7_DependencyInjectionOrnek.Entities;

namespace WebApi7_DependencyInjectionOrnek.Repository
{
    interface IProductRepository : IBaseRepository<Listing>
    {
    }
}
