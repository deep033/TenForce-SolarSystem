using log4net;
using log4net.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;
using Test_Taste_Console_Application.Constants;
using Test_Taste_Console_Application.Domain.Services;
using Test_Taste_Console_Application.Domain.Services.Interfaces;
using Test_Taste_Console_Application.Utilities;
using System.Threading.Tasks;
namespace Test_Taste_Console_Application
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            //The ConfigureServices function configures the services.
            ConfigureServices(serviceCollection);
            
            //The RunServiceOperations function executes the code that can create the outputs.
            await RunServiceOperations(serviceCollection);
        }

        private static async Task RunServiceOperations(IServiceCollection serviceCollection)
        {
            using var serviceProvider = serviceCollection.BuildServiceProvider();

            try
            {
                //The service provider gets the services.
                var screenOutputService = serviceProvider.GetRequiredService<IOutputService>();

                Console.WriteLine("Loading data...");

                await screenOutputService.OutputAllPlanetsAndTheirAverageMoonGravityToConsole();
                await screenOutputService.OutputAllPlanetsAndTheirAverageMoonTemperatureToConsole();
                await screenOutputService.OutputAllMoonsAndTheirMassToConsole();
                await screenOutputService.OutputAllPlanetsAndTheirMoonsToConsole();
            }
            catch (Exception exception)
            {
                //The users and developers can see the thrown exceptions.
                Logger.Instance.Error($"{LoggerMessage.ScreenOutputOperationFailed}{exception.Message}");
                Console.WriteLine($"{ExceptionMessage.ScreenOutputOperationFailed}{exception.Message}");
                System.Diagnostics.Debug.WriteLine($"{ExceptionMessage.ScreenOutputOperationFailed}{exception.Message}");
            }
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            //The function configures all the services.
            XmlConfigurator.Configure(LogManager.GetRepository(Assembly.GetEntryAssembly()),
                new FileInfo(ConfigurationFileName.Logger));

            //Load API configuration.
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile("appsettings.local.json", optional: true)
                .Build();

            serviceCollection.AddSingleton<IConfiguration>(configuration);

            serviceCollection.AddHttpClient<HttpClientService>();
            serviceCollection.AddSingleton<IPlanetService, PlanetService>();
            serviceCollection.AddSingleton<IOutputService, ScreenOutputService>();
            serviceCollection.AddSingleton<IMoonService, MoonService>();
        }
    }
}
