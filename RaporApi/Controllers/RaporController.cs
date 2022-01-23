using Experimental.System.Messaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RaporApi.context;
using RaporApi.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RaporApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaporController : ControllerBase
    {

        private string urlRaporBilgileri = "https://localhost:44396/api/Rapor";
        private readonly contextRapor _rpContext;

        public RaporController(contextRapor contx)
        {
            _rpContext = contx;
        }
        [HttpGet]
        public IActionResult IndexAsync()
        {
            msqm mq = new msqm();
            if (mq.msmqGet())
            {
                if(SetRaporDB())
                    return Ok("True");
                else
                    return Ok("False");
            }
            else
                return Ok("False");
        }

   
        public bool SetRaporDB()
        {
            bool result = false;
            try
            {
                Rapor rp = new Rapor();
                rp.uuid = 0;
                rp.rapordurumu = "Hazırlanıyor";
                rp.raportaleptarihi = DateTime.Now;
                _rpContext.Add(rp);
                if (_rpContext.SaveChanges() > 0)
                    result = true;
                else
                    result = false;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

    }
}
