using Microsoft.AspNetCore.Mvc;
using Weatherapp.Services;

namespace Weatherapp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly WeatherService _weatherService;
    private readonly TransportImpactService _transportImpactService;

    public WeatherController(WeatherService weatherService, TransportImpactService transportImpactService)
    {
        _weatherService = weatherService;
        _transportImpactService = transportImpactService;
    }

    [HttpGet]
    public async Task<IActionResult> GetWeather(double lat, double lon)
    {
        var weather = await _weatherService.GetWeatherAsync(lat, lon);

        if (weather == null)
        {
            return NotFound("Kunde inte hämta väderdata.");
        }

        var impact = _transportImpactService.Evaluate(weather);

        return Ok(impact);
    }
}