using Banking.API.Infrastructure.Core.Exceptions;
using Banking.API.Infrastructure.Database.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Banking.API.Infrastructure.Service.TransactionProcessing
{
    public class WithdrawTransaction : BaseTransaction, ITransaction
    {
        private readonly BankingAccount _account;
        private readonly decimal _amount;

        public WithdrawTransaction(BankingAccount account, decimal amount)
        {
            _account = account;
            _amount = amount;
        }

        public override async Task ExecuteAsync(TransactionManager context, CancellationToken cancellation = default(CancellationToken))
        {
            if (_account.CurrentBalance - _amount < 0)
                throw new InvalidTransactionException(_account.Id);

            _account.CurrentBalance -= _amount;

            await context.AccountRepository.UpdateAsync(_account.Id, _account, cancellation);
            await context.TransactionRepository.CreateAsync(new Transaction() {
                Amount = -_amount,
                BankingAccountId = _account.Id,
                CreatedDate = DateTime.UtcNow,
            }, cancellation);
        }
    }
}
