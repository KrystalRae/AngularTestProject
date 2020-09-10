using EverWealth.Models;
using EverWealth.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EverWealth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherForecastController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet]
        public async Task<WeatherInfo> Get()
        {
            // I did start out with hard coded values just to get the front end displaying and formatted, then came back and added the WeatherService to get actual data.
            // The weatherInfo could be cached for a few minutes so save on API calls to the weather service. This would increase reponse times.
            var weatherInfo = await _weatherService.GetWeatherInformation();
            weatherInfo.Date = $"{DateTime.Now.ToString("hh:mm tt dddd, dd MMM")} '{DateTime.Now.ToString("yy")}";
            weatherInfo.Risk = weatherInfo.Current.Uv > 7 ? "High" : "Low";

            return weatherInfo;
        }
    }
}
