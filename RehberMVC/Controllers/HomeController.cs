using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RehberMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RehberMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string url = "https://localhost:44396/api/Kisi";
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            List<Kisi> _kisiList = new List<Kisi>();
            using var client = new HttpClient();
            var response = await client.GetAsync(url);
            string result = response.Content.ReadAsStringAsync().Result;
            _kisiList = JsonConvert.DeserializeObject<List<Kisi>>(result);
            return View(_kisiList);
        }
        [HttpPost]
        public async Task<IActionResult> IndexAsync(Kisi kisi)
        {
            using var client = new HttpClient();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(kisi);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, data);
            string result = response.Content.ReadAsStringAsync().Result;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
