using Banking.API.Infrastructure.Service.TransactionProcessing;
using Microsoft.Extensions.DependencyInjection;

namespace Banking.API.Infrastructure.Service
{
    public static class ServiceRegisterExtension
    {
        public static void AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITransactionService, TransactionService>();
            serviceCollection.AddScoped<ITransactionManager, TransactionManager>();
            serviceCollection.AddScoped<IAccountService, AccountService>();
        }
    }
}
