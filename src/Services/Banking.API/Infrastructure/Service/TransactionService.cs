using AutoMapper;
using Banking.API.Infrastructure.Database.Models;
using Banking.API.Infrastructure.Database.Repositories;
using Banking.API.Infrastructure.Service.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Banking.API.Infrastructure.Service
{
    public interface ITransactionService
    {
        Task<List<TransactionModel>> GetTransactionsAsync(Guid bankingAccountId, CancellationToken cancellationToken = default(CancellationToken));
    }

    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly IMapper mapper;

        public TransactionService(ITransactionRepository transactionRepository, IMapper mapper)
        {
            this.transactionRepository = transactionRepository;
            this.mapper = mapper;
        }

        public Task<List<TransactionModel>> GetTransactionsAsync(Guid bankingAccountId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var data = transactionRepository.GetAll().Where(c => c.BankingAccountId == bankingAccountId).AsNoTracking();
            return mapper.ProjectTo<TransactionModel>(data).ToListAsync(cancellationToken);
        }
    }

    public interface ITransaction
    {
        Guid Id { get; set; }
        DateTime CreatedOn { get; set; } 
        TransactionStatus Status { get; set; }

        Task ExecuteAsync(CancellationToken cancellation = default(CancellationToken));
        Task Undo(CancellationToken cancellation = default(CancellationToken));
    }

    public abstract class BaseTransaction: ITransaction
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public TransactionStatus Status { get; set; } = TransactionStatus.Create;

        public abstract Task ExecuteAsync(CancellationToken cancellation = default(CancellationToken));
        public abstract Task Undo(CancellationToken cancellation = default(CancellationToken));
    }

    public class Deposit : BaseTransaction
    {
        private readonly BankingAccount _account;
        private readonly decimal _amount;

        public Deposit(BankingAccount account, decimal amount)
        {
            _account = account;
            _amount = amount;
        }

        public override Task ExecuteAsync(CancellationToken cancellation = default(CancellationToken))
        {
            _account.CurrentBalance += _amount;
            return Task.CompletedTask;
        }

        public override Task Undo(CancellationToken cancellation = default(CancellationToken))
        {
            _account.CurrentBalance -= _amount;
            return Task.CompletedTask;
        }
    }

    public class Withdraw : BaseTransaction
    {
        private readonly BankingAccount _account;
        private readonly decimal _amount;

        public Withdraw(BankingAccount account, decimal amount)
        {
            _account = account;
            _amount = amount;
        }

        public override Task ExecuteAsync(CancellationToken cancellation = default(CancellationToken))
        {
            _account.CurrentBalance -= _amount;
            return Task.CompletedTask;
        }

        public override Task Undo(CancellationToken cancellation = default(CancellationToken))
        {
            _account.CurrentBalance += _amount;
            return Task.CompletedTask;
        }
    }

    public class RecordTransaction : BaseTransaction
    {
        private readonly BankingAccount _account;
        private readonly decimal _amount;

        public RecordTransaction(BankingAccount account, decimal amount)
        {
            _account = account;
            _amount = amount;
        }

        public override Task ExecuteAsync(CancellationToken cancellation = default(CancellationToken))
        {
            return Task.CompletedTask;
        }

        public override Task Undo(CancellationToken cancellation = default(CancellationToken))
        {
            return Task.CompletedTask;
        }
    }

    public interface ITransactionManager
    {
        Task ProcessTransactionsAsync(CancellationToken cancellation = default(CancellationToken));
    }

    public class TransactionManager: ITransactionManager
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
