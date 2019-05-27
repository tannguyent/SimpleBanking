using Banking.API.Infrastructure.Core;
using Banking.API.Infrastructure.Database.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Banking.API.Infrastructure.Service.TransactionProcessing
{
    public class TransactionManager : ITransactionManager
    {
        private readonly List<ITransaction> _transactions = new List<ITransaction>();
        private readonly IUnitOfWork _unitOfWork;

        public TransactionManager(IUnitOfWork unitOfWork,
            IBankingAccountRepository accountRepository,
            ITransactionRepository transactionRepository,
            ITransactionHistoriesRepository transactionHistories
            )
        {
            _unitOfWork = unitOfWork;
            AccountRepository = accountRepository;
            TransactionRepository = transactionRepository;
            TransactionHistories = transactionHistories;
        }

        public IBankingAccountRepository AccountRepository { get; }
        public ITransactionRepository TransactionRepository { get; }
        public ITransactionHistoriesRepository TransactionHistories { get; }

        public void AddTransaction(ITransaction transaction)
        {
            _transactions.Add(transaction);
        }

        public async Task ProcessTransactionsAsync(CancellationToken cancellation = default(CancellationToken))
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                foreach (var trans in _transactions)
                {
                    await trans.ExecuteAsync(this, cancellation);
                }

                _unitOfWork.CommitTransaction();
            }
            catch (System.Exception)
            {
                _unitOfWork.RollbackTransaction();

                throw;
            }
        }
    }
}
