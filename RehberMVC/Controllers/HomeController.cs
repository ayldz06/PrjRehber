
using Microsoft.AspNetCore.Http.Extensions;
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
        private string urlKisi = "https://localhost:44396/api/Kisi";
        private string urlKisiBilgileri = "https://localhost:44396/api/KisiBilgileri";
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            List<Kisi> _kisiList = new List<Kisi>();
            using var client = new HttpClient();
            var response = await client.GetAsync(urlKisi);
            string result = response.Content.ReadAsStringAsync().Result;
            _kisiList = JsonConvert.DeserializeObject<List<Kisi>>(result);
            return View(_kisiList);
        }
        [HttpPost]
        public async Task<RedirectResult> IndexAsync(Kisi kisi)
        {
            using var client = new HttpClient();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(kisi);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(urlKisi, data);
            string result = response.Content.ReadAsStringAsync().Result;
            return Redirect("Home/Index");
        }
        [HttpPost]
        public async Task<RedirectResult> IletisimBilgileri(KisiBilgileri kisibilgileri)
        {
            using var client = new HttpClient();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(kisibilgileri);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(urlKisiBilgileri, data);
            string result = response.Content.ReadAsStringAsync().Result;
            return Redirect("IletisimBilgileri?uuid=" + kisibilgileri.uuid+"");

        }
        [HttpGet]
        public async Task<IActionResult> IletisimBilgileri(int uuid)
        {
            List<KisiBilgileri> _kisiBilgileriList = new List<KisiBilgileri>();
            using var client = new HttpClient();
            var response = await client.GetAsync(urlKisiBilgileri+ "/GetKisiBilgileri/" + uuid+"");
            string result = response.Content.ReadAsStringAsync().Result;
            _kisiBilgileriList = JsonConvert.DeserializeObject<List<KisiBilgileri>>(result);
            if (_kisiBilgileriList.Count > 0)
                ViewBag.Message = "True";
            return  View(_kisiBilgileriList);
        }

        [HttpGet]
        public async Task<RedirectResult> IletisimBilgileriSil(int iletisimid, int uuid)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(urlKisiBilgileri+"/DeleteKisiBilgileri/" + iletisimid + "");
            string result = response.Content.ReadAsStringAsync().Result;
            return Redirect("IletisimBilgileri?uuid=" + uuid + "");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
