using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RaporApi.model
{
    public class Rapor
    {
        [Key]
        public int uuid { get; set; }
        public DateTime raportaleptarihi { get; set; }
        public string rapordurumu { get; set; }
    }
}
