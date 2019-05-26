using Banking.API.Infrastructure.Database.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banking.API.Infrastructure.Database
{
    public static class ServiceRegisterExtension
    {
        public static void AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITransactionRepository, TransactionRepository>();
        }
    }
}
