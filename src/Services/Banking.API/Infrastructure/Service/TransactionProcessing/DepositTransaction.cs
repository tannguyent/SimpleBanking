using Banking.API.Infrastructure.Database.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Banking.API.Infrastructure.Service.TransactionProcessing
{
    public class DepositTransaction : BaseTransaction, ITransaction
    {
        private readonly BankingAccount _account;
        private readonly decimal _amount;

        public DepositTransaction(BankingAccount account, decimal amount)
        {
            _account = account;
            _amount = amount;
        }

        public override Task ExecuteAsync(CancellationToken cancellation = default(CancellationToken))
        {
            _account.CurrentBalance += _amount;
            return Task.CompletedTask;
        }
    }
}
