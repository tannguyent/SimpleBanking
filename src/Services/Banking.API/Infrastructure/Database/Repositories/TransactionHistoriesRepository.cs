using Banking.API.Infrastructure.Core;
using Banking.API.Infrastructure.Database.Context;
using Banking.API.Infrastructure.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banking.API.Infrastructure.Database.Repositories
{
    public interface ITransactionHistoriesRepository : IGenericRepository<TransactionHistory>
    {
    }

    public class TransactionHistoriesRepository: GenericRepository<TransactionHistory>, ITransactionHistoriesRepository
    {
        public TransactionHistoriesRepository(BankingDbContext dbContext): base(dbContext)
        {
        }
    }
}
