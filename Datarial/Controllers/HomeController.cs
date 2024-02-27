using Datarial.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Datarial.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GeoLocation()
        {
            return View();
        }

        public IActionResult Festivos()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> ObtenerIp(string ipAddress)
        {
            HttpClient client = new();
            GeoLocationInfo geoInfo;
            HttpResponseMessage response = await client.GetAsync($"http://ip-api.com/json/{ipAddress}");

            if (response.IsSuccessStatusCode)
            {
                string jsonResult = await response.Content.ReadAsStringAsync();
                geoInfo = JsonConvert.DeserializeObject<GeoLocationInfo>(jsonResult);
            }
            else
            {
                geoInfo = new()
                {
                    Status = "Failed"
                };
            }

            return View("GeoLocation", geoInfo);
        }

        [HttpPost]
        public async Task<IActionResult> ObtenerFestivos(string codigoPais)
        {
            HttpClient client = new();
            List<Festivos> festivos;
            HttpResponseMessage response = await client.GetAsync($"https://date.nager.at/api/v3/PublicHolidays/2023/{codigoPais}");

            if (response.IsSuccessStatusCode)
            {
                string jsonResult = await response.Content.ReadAsStringAsync();
                festivos = JsonConvert.DeserializeObject<List<Festivos>>(jsonResult);
            }
            else
            {
                festivos = new();
            }

            return View("Festivos", festivos);
        }
    }
}