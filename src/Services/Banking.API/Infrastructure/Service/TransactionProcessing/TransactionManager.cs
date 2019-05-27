using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Banking.API.Infrastructure.Service.TransactionProcessing
{
    public class TransactionManager : ITransactionManager
    {
        private readonly List<ITransaction> _transactions = new List<ITransaction>();

        public void AddTransaction(ITransaction transaction)
        {
            _transactions.Add(transaction);
        }

        public async Task ProcessTransactionsAsync(CancellationToken cancellation = default(CancellationToken))
        {
            foreach (var trans in _transactions)
            {
                await trans.ExecuteAsync(cancellation);
            }
        }
    }
}
