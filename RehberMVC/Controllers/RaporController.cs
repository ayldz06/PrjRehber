using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RehberMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace RehberMVC.Controllers
{
    public class RaporController : Controller
    {
        private readonly ILogger<RaporController> _logger;
        private string urlRapor= "https://localhost:44388/api/Rapor";
        public RaporController(ILogger<RaporController> logger)
        {
            _logger = logger;
        }
        public IActionResult IndexAsync()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> KonumRaporuGetir()
        {
            List<KonumRapor> _konumRapor = new List<KonumRapor>();
            using var client = new HttpClient();
            var response = await client.GetAsync(urlRapor);
            string result = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<List<KonumRapor>>(result);
            return View(data);
        }
    }
}
