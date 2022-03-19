using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi6_DependencyInjectionLifeTime.Models
{
    public interface IGuidValue
    {
        // interfaceler içerisinde field tanımlanamaz...
        //Guid uid;

        // Guid => Global Unique Identity... Unique değerler oluşturmak için kullanılır.. Bu değer oluşurken zman, işlemci çalışma hızı vb. değerler dikkate alınarak oluşur. Ve aynı değerin oluşması imkansızdır...
        Guid Guid { get; set; }
    }
}
