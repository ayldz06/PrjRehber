﻿using System;
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
        public string soyad { get; set; }
        public string firma { get; set; }
    }
}
