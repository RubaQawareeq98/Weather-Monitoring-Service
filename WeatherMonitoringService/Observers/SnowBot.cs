using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using WeatherMonitoringService.Models;
using WeatherMonitoringService.Observables;

namespace WeatherMonitoringService.Observers;

public class SnowBot : WeatherBot, IWeatherObserver
{
    [JsonPropertyName("temperatureThreshold")]
    public decimal TemperatureThreshold { get; init; }

    private readonly ILogger<SnowBot>? _logger;
    
    public SnowBot()
    {
        
    }

    public SnowBot(ILogger<SnowBot> logger)
    {
        _logger = logger;
    }

    public void Update(WeatherData weatherData)
    {
        if (Enabled && TemperatureThreshold > weatherData.Temperature)
        {
            _logger?.LogInformation("{Message}",Message);
        }
    }
}
