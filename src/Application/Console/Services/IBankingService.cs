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
        Task<List<TransactionModel>> GetTransactionsAsync(Guid userId, CancellationToken cancellationToken = default(CancellationToken));

        Task RecordDepositTransactionAsync(RequestCreateTransactionModel request, CancellationToken cancellationToken = default(CancellationToken));
        Task RecordWithdrawTransactionAsync(RequestCreateTransactionModel request, CancellationToken cancellationToken = default(CancellationToken));
    }
}
