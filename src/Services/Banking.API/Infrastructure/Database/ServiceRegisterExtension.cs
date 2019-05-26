using Banking.API.Infrastructure.Database.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Banking.API.Infrastructure.Database
{
    public static class ServiceRegisterExtension
    {
        public static void AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITransactionRepository, TransactionRepository>();
            serviceCollection.AddScoped<ITransactionHistoriesRepository, TransactionHistoriesRepository>();
            serviceCollection.AddScoped<IDebitBankingAccountRepository, DebitBankingAccountRepository>();
            serviceCollection.AddScoped<ICreditBankingAccountRepository, CreditBankingAccountRepository>();
        }
    }
}
