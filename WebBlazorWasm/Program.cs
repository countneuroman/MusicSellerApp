using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebBlazorWasm;
using WebBlazorWasm.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddScoped(_ =>
{
    var apiUrl = new Uri("http://localhost:8930/");
    return new HttpClient()
    {
        BaseAddress = apiUrl
    };
});

await builder.Build().RunAsync();