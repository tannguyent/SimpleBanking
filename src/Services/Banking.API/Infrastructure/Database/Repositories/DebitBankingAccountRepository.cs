using Banking.API.Infrastructure.Core;
using Banking.API.Infrastructure.Database.Context;
using Banking.API.Infrastructure.Database.Models;

namespace Banking.API.Infrastructure.Database.Repositories
{
    public interface IDebitBankingAccountRepository : IGenericRepository<DebitBankingAccount>
    {
    }

    public class DebitBankingAccountRepository : GenericRepository<DebitBankingAccount>, IDebitBankingAccountRepository
    {
        public DebitBankingAccountRepository(BankingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
