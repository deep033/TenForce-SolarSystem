using Microsoft.Extensions.Configuration;


var configuration = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile("appsettings.local.json", optional: true).Build();

var baseUrl = configuration["SolarSystemApi:BaseUrl"];
var apiKey = configuration["SolarSystemApi:ApiKey"];

//Console.WriteLine(baseUrl);
