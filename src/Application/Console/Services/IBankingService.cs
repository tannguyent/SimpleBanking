using SimpleBankingApp.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleBankingApp.Services
{
    public interface IBankingService
    {
        Task<BankingAccountModel> CreateDebitAccountAsync(Guid userId, CancellationToken cancellationToken = default(CancellationToken));
        Task<BankingAccountModel> GetBankingAccountByUserIdAsync(Guid userId, CancellationToken cancellationToken = default(CancellationToken));
        Task<BankingAccountModel> GetBankingAccountAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken));
        Task<List<TransactionModel>> GetTransactionsAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
