using Banking.API.Infrastructure.Core;
using Banking.API.Infrastructure.Database.Context;
using Banking.API.Infrastructure.Database.Models;

namespace Banking.API.Infrastructure.Database.Repositories
{
    public interface IBankingAccountRepository : IGenericRepository<BankingAccount>
    {
    }

    public class BankingAccountRepository : GenericRepository<BankingAccount>, IBankingAccountRepository
    {
        public BankingAccountRepository(BankingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
