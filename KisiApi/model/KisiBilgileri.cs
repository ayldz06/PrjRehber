using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KisiApi.model
{
    public class KisiBilgileri
    {
        [Key]
        public int iletisimid { get; set; }
        public string telefonno { get; set; }
        public int email { get; set; }
        public string konum { get; set; }
        public string bilgiicerigi { get; set; }
        public int uuid { get; set; }
    }
}
