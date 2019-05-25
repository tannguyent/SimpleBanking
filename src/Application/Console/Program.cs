using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SimpleBankingApp.Account.Services;
using SimpleBankingApp.Models;
using SimpleBankingApp.Print.Handlers;

namespace SimpleBankingApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // create service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // run app
            var app = serviceProvider.GetService<App>();
            app.Run().Wait();

        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // add logging
            serviceCollection.AddLogging(configure => configure.AddConsole())
                             .Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Information);

            // build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("app-settings.json", false)
                .Build();

            serviceCollection.AddOptions();
            serviceCollection.Configure<ApplicationSettings>(configuration);
            ConfigureConsole(configuration);

            // add context
            serviceCollection.AddSingleton<ApplicationContext>();

            // add app
            serviceCollection.AddTransient<App>();

            // add cqrs
            serviceCollection.AddCqrs(typeof(ShowHomeScreenEventHandler).Assembly);

            // add service 
            serviceCollection.AddHttpClient<IAccountService, AccountService>();
        }

        private static void ConfigureConsole(IConfigurationRoot configuration)
        {
            System.Console.Title = configuration.GetSection("Configuration:ConsoleTitle").Value;
        }
    }
}
