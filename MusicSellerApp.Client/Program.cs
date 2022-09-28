using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MusicSellerApp.Client;
using MusicSellerApp.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddScoped(_ =>
{
    var apiUrl = new Uri("http://musicsellerapp.server/");
    return new HttpClient()
    {
        BaseAddress = apiUrl
    };
});

await builder.Build().RunAsync();