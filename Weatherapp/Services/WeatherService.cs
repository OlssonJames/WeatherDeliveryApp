using Weatherapp.Models; // ger tillgång till WeatherResponse och CurrentWeather
using System.Globalization;
namespace Weatherapp.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<WeatherResponse?> GetWeatherAsync(double lat, double lon)
        {
            var latString = lat.ToString(CultureInfo.InvariantCulture);
            var lonString = lon.ToString(CultureInfo.InvariantCulture);

            var url = $"https://api.open-meteo.com/v1/forecast?latitude={latString}&longitude={lonString}&current=temperature_2m,wind_speed_10m,precipitation";

            var response = await _httpClient.GetFromJsonAsync<WeatherResponse>(url);
            return response;
        }
    }
    
}

