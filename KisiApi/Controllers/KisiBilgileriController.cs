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
    public class KisiBilgileriController : ControllerBase
    {
        private readonly contextkisi _contextKisi;

        public KisiBilgileriController(contextkisi contx)
        {
            _contextKisi = contx;
        }
        [HttpPost]
        public IActionResult SetKisiBilgileri([FromBody] KisiBilgileri data)
        {
            _contextKisi.Add(data);
            if (_contextKisi.SaveChanges() > 0)
            {
                return Ok("True");
            }
            return Ok("False");

        }
        [HttpGet("GetKisiBilgileri/{uuid}")]
        public IActionResult GetKisiBilgileri(int uuid)
        {
            var kisiBilgileri = _contextKisi.KisiBilgileri.Where(x => x.uuid == uuid).ToList();
            return Ok(kisiBilgileri.ToList());
        }

        [HttpGet("DeleteKisiBilgileri/{id}")]
        public IActionResult DeleteKisiBilgileri(int id)
        {
            var kisiBilgileri = _contextKisi.KisiBilgileri.Find(id);
            _contextKisi.KisiBilgileri.Remove(kisiBilgileri);
            if (_contextKisi.SaveChanges() > 0)
                return Ok("True");
            else
                return Ok("False");
        }
    }
}
