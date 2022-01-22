using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KisiApi.model
{
    public class Kisi
    {
        [Key]
        public int uuid { get; set; }
        public string ad { get; set; }
        public int soyad { get; set; }
        public int firma { get; set; }
        public int iletisimid { get; set; }
    }
}
