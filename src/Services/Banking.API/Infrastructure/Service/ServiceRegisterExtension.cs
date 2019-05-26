using Microsoft.Extensions.DependencyInjection;

namespace Banking.API.Infrastructure.Service
{
    public static class ServiceRegisterExtension
    {
        public static void AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITransactionService, TransactionService>();
            serviceCollection.AddScoped<IDebitBankingAccountService, DebitBankingAccountService>();
            serviceCollection.AddScoped<ICreditBankingAccountService, CreditBankingAccountService>();
        }
    }
}
