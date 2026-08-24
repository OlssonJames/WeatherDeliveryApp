namespace Weatherapp.Models
{
    public class DeliveryImpact
    {
        public double TemperatureC { get; set; }
        public double WindSpeedKmh { get; set; }
        public double PrecipitationMm { get; set; }
        public int DelayMinutes { get; set; }
        public string RiskLevel { get; set; } = string.Empty;
        public List<string> Warnings { get; set; } = new();
    }
}
