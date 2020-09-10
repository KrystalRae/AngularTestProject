using EverWealth.Models;
using System.Threading.Tasks;

namespace EverWealth.Services
{
    public interface IWeatherService
    {
        public Task<WeatherInfo> GetWeatherInformation();
    }
}
