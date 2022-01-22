using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RehberMVC.Models
{
    public class KisiBilgileri
    {
        public int iletisimid { get; set; }
        public string telefonno { get; set; }
        public string email { get; set; }
        public string konum { get; set; }
        public string bilgiicerigi { get; set; }
        public int uuid { get; set; }
    }
}
