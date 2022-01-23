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
    public class RaporController : ControllerBase
    {
        private readonly contextkisi _contextKisi;
        public RaporController(contextkisi contx)
        {
            _contextKisi = contx;
        }
        [HttpGet]
        public IActionResult GetKisiIletisimBilgileri()
        {
            List<KonumRapor> _konumRapor = new List<KonumRapor>();
            var result = from a in _contextKisi.Kisi
                         join b in _contextKisi.KisiBilgileri on a.uuid equals b.uuid
                         select new
                         {
                             Uuid=a.uuid,
                             AdSoyad=a.ad+" "+a.soyad,
                             TelefonNo=b.telefonno,
                             Konum=b.konum
                         };

            foreach(var item in result.Select(x => x.Konum).Distinct().ToList())
            {
                KonumRapor _kr = new KonumRapor();
                _kr.Konum = item;
                _kr.TelefonSayisi = result.Where(x => x.Konum == item).Count();
                _kr.KisiSayisi = result.Where(x => x.Konum == item).Select(y => y.Uuid).Distinct().Count();
                _konumRapor.Add(_kr);
            }
            return Ok(_konumRapor);
        }
    }
}
