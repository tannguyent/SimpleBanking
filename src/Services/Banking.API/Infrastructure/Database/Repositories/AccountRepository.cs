using Banking.API.Infrastructure.Core;
using Banking.API.Infrastructure.Database.Context;
using Banking.API.Infrastructure.Database.Models;

namespace Banking.API.Infrastructure.Database.Repositories
{
    public interface IAccountRepository : IGenericRepository<BankingAccount>
    {
    }

    public class AccountRepository : GenericRepository<BankingAccount>, IAccountRepository
    {
        public AccountRepository(BankingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
