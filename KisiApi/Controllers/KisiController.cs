using KisiApi.context;
using KisiApi.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KisiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KisiController : ControllerBase
    {
        private readonly contextkisi _contextKisi;

        public KisiController(contextkisi contx)
        {
            _contextKisi = contx;
        }
        [HttpPost]
        public IActionResult SetKisi([FromBody] Kisi data)
        {
            _contextKisi.Add(data);
            if (_contextKisi.SaveChanges() > 0)
            {
                return Ok("True");
            }
            return Ok("False");
            
        }

        [HttpGet]
        public IActionResult GetKisi()
        {
            var kisiler = _contextKisi.Kisi.ToList();
            return Ok(kisiler.ToList());
            //return Ok("A");
        }
       
    }
}
