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

services.AddHttpClient<IHttpClientService, HttpClientService>((client, serviceprovider) => new HttpClientService(client, baseUrl, apiKey));
services.AddTransient<IMoonService, MoonService>();
services.AddTransient<IPlanetService, PlanetService>();
services.AddTransient<IConsoleOutputService, ConsoleOutputService>();

using var provider = services.BuildServiceProvider();

try
{
    Console.WriteLine("Loading data...");

    var httpService = provider.GetRequiredService<IHttpClientService>();
    var moonService = provider.GetRequiredService<IMoonService>();
    var planetService = provider.GetRequiredService<IPlanetService>();
    var consoleService = provider.GetRequiredService<IConsoleOutputService>();

    var bodies = await httpService.GetBodiesAsync();
    var moons = moonService.GetMoons(bodies);
    var planets = planetService.GetPlanets(bodies, moons);

    Console.WriteLine("Writing data...");

    consoleService.PrintAvgMoonGravity(planets);
    consoleService.PrintMoonMass(moons);
    consoleService.PrintPlanetsAndMoons(planets);
    consoleService.PrintAvgMoonTemp(planets);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
