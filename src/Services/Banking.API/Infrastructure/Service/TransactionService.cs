using AutoMapper;
using Banking.API.Infrastructure.Core.Exceptions;
using Banking.API.Infrastructure.Database.Models;
using Banking.API.Infrastructure.Database.Repositories;
using Banking.API.Infrastructure.Service.Models;
using Banking.API.Infrastructure.Service.TransactionProcessing;
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
        Task<TransactionModel> RecordDepositTransactionAsync(Guid bankingAccountId, decimal amount, CancellationToken cancellationToken = default(CancellationToken));
        Task<TransactionModel> RecordWithdrawTransactionAsync(Guid bankingAccountId, decimal amount, CancellationToken cancellationToken = default(CancellationToken));
    }

    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly IAccountRepository accountRepository;
        private readonly ITransactionManager transactionManager;
        private readonly IMapper mapper;

        public TransactionService(ITransactionRepository transactionRepository, 
            IAccountRepository accountRepository,
            ITransactionManager transactionManager,
            IMapper mapper)
        {
            this.transactionRepository = transactionRepository;
            this.accountRepository = accountRepository;
            this.transactionManager = transactionManager;
            this.mapper = mapper;
        }

        public Task<List<TransactionModel>> GetTransactionsAsync(Guid bankingAccountId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var data = transactionRepository.GetAll().Where(c => c.BankingAccountId == bankingAccountId).AsNoTracking();
            return mapper.ProjectTo<TransactionModel>(data).ToListAsync(cancellationToken);
        }

        public async Task<TransactionModel> RecordDepositTransactionAsync(Guid bankingAccountId, decimal amount, CancellationToken cancellationToken = default(CancellationToken))
        {
            var account = await accountRepository.GetByIdAsync(bankingAccountId, cancellationToken);
            if (account == null)
                throw new AccountNotFoundException(bankingAccountId);

            var depositTransaction = new DepositTransaction(account, amount);
            transactionManager.AddTransaction(depositTransaction);

            await transactionManager.ProcessTransactionsAsync();

            throw new NotImplementedException();
        }

        public async Task<TransactionModel> RecordWithdrawTransactionAsync(Guid bankingAccountId, decimal amount, CancellationToken cancellationToken = default(CancellationToken))
        {
            var account = await accountRepository.GetByIdAsync(bankingAccountId, cancellationToken);
            if (account == null)
                throw new AccountNotFoundException(bankingAccountId);

            var withDrawTransaction = new WithdrawTransaction(account, amount);
            transactionManager.AddTransaction(withDrawTransaction);

            await transactionManager.ProcessTransactionsAsync();

            throw new NotImplementedException();
        }
    }
}
