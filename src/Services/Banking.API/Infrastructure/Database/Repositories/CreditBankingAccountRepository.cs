using Banking.API.Infrastructure.Core;
using Banking.API.Infrastructure.Database.Context;
using Banking.API.Infrastructure.Database.Models;

namespace Banking.API.Infrastructure.Database.Repositories
{
    public interface ICreditBankingAccountRepository : IGenericRepository<CreditBankingAccount>
    {
    }

    public class CreditBankingAccountRepository : GenericRepository<CreditBankingAccount>, ICreditBankingAccountRepository
    {
        public CreditBankingAccountRepository(BankingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
