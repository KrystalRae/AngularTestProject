using EverWealth.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace EverWealth.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<WeatherInfo> GetWeatherInformation()
        {
            // If I had more time I would use the browsers location service to obtain the city instead of hard coding brisbane into the uri.
            // Try catch ... depending on an external dependency should be safter than this.
            var url = new Uri("https://api.weatherapi.com/v1/current.json?key=d52e981cc54a400b8fd101419200809&q=Brisbane");
            var result = await _httpClient.GetStringAsync(url);

            return JsonConvert.DeserializeObject<WeatherInfo>(result);
        }
    }
}
