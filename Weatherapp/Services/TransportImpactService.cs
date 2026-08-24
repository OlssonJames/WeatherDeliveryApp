using Weatherapp.Models;

namespace Weatherapp.Services;

public class TransportImpactService
{
    public DeliveryImpact Evaluate(WeatherResponse weather)
    {
        var current = weather.current;

        var impact = new DeliveryImpact
        {
            TemperatureC = current.temperature_2m,
            WindSpeedKmh = current.wind_speed_10m,
            PrecipitationMm = current.precipitation
        };

        // Regel 1: Halka/is vid temperaturer nära noll
        if (current.temperature_2m <= 0)
        {
            impact.DelayMinutes += 30;
            impact.Warnings.Add("Risk för halka/is – räkna med längre körtider.");
        }

        // Regel 2: Kraftig vind
        if (current.wind_speed_10m >= 50)
        {
            impact.DelayMinutes += 20;
            impact.Warnings.Add("Kraftig vind – risk för inställda/försenade transporter.");
        }
        else if (current.wind_speed_10m >= 30)
        {
            impact.Warnings.Add("Måttlig vind – kan påverka känsliga transporter (t.ex. färja).");
        }

        // Regel 3: Nederbörd
        if (current.precipitation >= 10)
        {
            impact.DelayMinutes += 15;
            impact.Warnings.Add("Kraftigt regn/snöfall – sänkt hastighet rekommenderas.");
        }
        else if (current.precipitation > 0)
        {
            impact.Warnings.Add("Lätt nederbörd – mindre påverkan på leveranstider.");
        }

        // Sätt en samlad risknivå baserat på total försening
        impact.RiskLevel = impact.DelayMinutes switch
        {
            0 => "Låg",
            <= 20 => "Medel",
            _ => "Hög"
        };

        if (impact.Warnings.Count == 0)
        {
            impact.Warnings.Add("Inga väderrelaterade risker just nu.");
        }

        return impact;
    }
}