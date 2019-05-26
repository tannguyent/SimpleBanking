using SimpleBankingApp.Banking.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleBankingApp.Bank.Services
{
    public interface IBankingService
    {
        Task<List<TransactionModel>> GetTransactionsAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
