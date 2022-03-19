using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi6_DependencyInjectionLifeTime.Models
{
    public class GuidValue : IGuidValue
    {
        public Guid Guid { get; set; }

        public GuidValue()
        {
            Guid = Guid.NewGuid(); // guid değeri oluştur...
        }
    }
}
