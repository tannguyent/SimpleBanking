using System.Threading;
using System.Threading.Tasks;

namespace Banking.API.Infrastructure.Service.TransactionProcessing
{
    public interface ITransactionManager
    {
        void AddTransaction(ITransaction transaction);

        Task ProcessTransactionsAsync(CancellationToken cancellation = default(CancellationToken));
    }
}
