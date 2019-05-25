using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SimpleBankingApp.Models;
using SimpleBankingApp.Print.Events;
using SimpleBankingApp.Print.Handlers;
using Xer.Cqrs.CommandStack;
using Xer.Cqrs.EventStack;
using Xer.Delegator.Registration;

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
            serviceCollection.AddSingleton(new LoggerFactory()
                .AddConsole()
                .AddDebug());
            serviceCollection.AddLogging();

            // build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("app-settings.json", false)
                .Build();

            serviceCollection.AddOptions();
            serviceCollection.Configure<ApplicationSettings>(configuration.GetSection("Configuration"));
            ConfigureConsole(configuration);

            // add context
            serviceCollection.AddSingleton<ApplicationContext>();

            // add app
            serviceCollection.AddTransient<App>();

            // add cqrs
            serviceCollection.AddCqrs(typeof(ShowHomeScreenEventHandler).Assembly);
        }

        private static void ConfigureConsole(IConfigurationRoot configuration)
        {
            System.Console.Title = configuration.GetSection("Configuration:ConsoleTitle").Value;
        }
    }
}
