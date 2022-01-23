using Experimental.System.Messaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        private const string QueueName = @".\private$\KonumRaporMQ";
        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            MessageQueue queue;
            queue = GetMQueye();

            List<KonumRapor> _konumRapor = new List<KonumRapor>();
            using var client = new HttpClient();
            var response = await client.GetAsync(urlRaporBilgileri);
            string result = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<List<KonumRapor>>(result);
            return Ok(data);
        }

        private MessageQueue GetMQueye()
        {
            MessageQueue queue = null;
            if (MessageQueue.Exists(QueueName))
            {
                queue = new MessageQueue(QueueName);
            }
            else
            {
                try
                {
                    queue = MessageQueue.Create(QueueName, true);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return queue;
        }
    }
}
