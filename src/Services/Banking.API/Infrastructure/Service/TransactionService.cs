using AutoMapper;
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
}
