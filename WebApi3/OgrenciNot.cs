using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi3
{
    public class OgrenciNot
    {
        public float Vize { get; set; }
        public float Final { get; set; }
        public float Ortalama
        {
            get
            {
                return Vize * 0.4f + Final * 0.6f;
            }
        }
    }
}
