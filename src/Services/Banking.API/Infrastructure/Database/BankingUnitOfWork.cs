using Banking.API.Infrastructure.Core;
using Banking.API.Infrastructure.Database.Context;

namespace Banking.API.Infrastructure.Database
{
    public class BankingUnitOfWork : UnitOfWork
    {
        public BankingUnitOfWork(BankingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
