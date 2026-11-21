using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SolarSystemPrj.Interfaces;
using SolarSystemPrj.Services;


var configuration = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile("appsettings.local.json", optional: true).Build();

var baseUrl = configuration["SolarSystemApi:BaseUrl"];
var apiKey = configuration["SolarSystemApi:ApiKey"];

//Console.WriteLine(baseUrl);

var services = new ServiceCollection();

services.AddHttpClient<IHttpClientService, HttpClientService>((client, sp) => new HttpClientService(client, baseUrl, apiKey));
services.AddTransient<IMoonService, MoonService>();
using var provider = services.BuildServiceProvider();

try
{
    Console.WriteLine("Loading data...");

    var httpService = provider.GetRequiredService<IHttpClientService>();
    var moonService = provider.GetRequiredService<IMoonService>();

    var bodies = await httpService.GetBodiesAsync();
    var moons = moonService.GetMoons(bodies);

    Console.WriteLine($"Total bodies: {bodies.Count}");
    Console.WriteLine($"Total moons: {moons.Count}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
