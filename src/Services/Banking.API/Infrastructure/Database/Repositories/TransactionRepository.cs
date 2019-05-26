using Banking.API.Infrastructure.Core;
using Banking.API.Infrastructure.Database.Context;
using Banking.API.Infrastructure.Database.Models;

namespace Banking.API.Infrastructure.Database.Repositories
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
    }

    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(BankingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
