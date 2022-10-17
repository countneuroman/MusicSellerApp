using System.Text.Json;
using MusicSellerApp.Common;

namespace WebBlazorWasm.Services;

public interface IWeatherForecastService
{
    public Task<WeatherForecast[]?> GetWeatherData();
}

public class WeatherForecastService : IWeatherForecastService
{
    private HttpClient _httpClient;

    public WeatherForecastService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<WeatherForecast[]?> GetWeatherData()
    {
        var response = await _httpClient.GetAsync("WeatherForecast");
        response.EnsureSuccessStatusCode();
        var resultString =  await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<WeatherForecast[]>(resultString);
    }
}