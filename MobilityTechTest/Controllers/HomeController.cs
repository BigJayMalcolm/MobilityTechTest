using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobilityTechTest.Models;
using Newtonsoft.Json;

namespace MobilityTechTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string _apiKey = "fa66ecec9d5434357c488f5943ba729b";
        private readonly string _sessionKey = "SearchHistory";

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var value = HttpContext.Session.GetString(_sessionKey);

            if (value == null)
            {
                HttpContext.Session.SetString(_sessionKey, JsonConvert.SerializeObject(new List<string>()));
            }

            return View(JsonConvert.DeserializeObject<List<string>>(HttpContext.Session.GetString(_sessionKey)));
        }

        public IActionResult Forecast(string searchTerm)
        {
            try
            {
                CurrentWeatherModel weatherSearch = Query(searchTerm);

                if (weatherSearch.ValidData)
                {
                    List<string> list = JsonConvert.DeserializeObject<List<string>>(HttpContext.Session.GetString(_sessionKey));
                    list.Add(searchTerm);
                    HttpContext.Session.SetString(_sessionKey, JsonConvert.SerializeObject(list));
                }
                else
                {
                    return RedirectToAction("Index");
                }

                return View(weatherSearch);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public CurrentWeatherModel Query(string queryString)
        {
            return Task.Run(async () => await QueryAsync(queryString).ConfigureAwait(false)).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public async Task<CurrentWeatherModel> QueryAsync(string queryString)
        {
            var response = await _httpClient.GetStringAsync(new Uri("http://api.openweathermap.org/data/2.5/weather?appid=" + _apiKey + "&q=" + queryString)).ConfigureAwait(false);
            var currentWeatherModel = new CurrentWeatherModel(response);

            return currentWeatherModel.ValidData ? currentWeatherModel : null;
        }
    }
}