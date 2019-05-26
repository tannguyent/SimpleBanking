using Banking.API.Infrastructure.Service.Models;
using Banking.API.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Banking.API.Infrastructure.Service
{
    public interface IBankingAccountService
    {
        Task<BankingAccountModel> CreateAsync(RequestCreateAccountModel model, CancellationToken cancellationToken = default(CancellationToken));

        Task<BankingAccountModel> GetByAccountIdAsync(Guid accountId, CancellationToken cancellationToken = default(CancellationToken));

        Task<BankingAccountModel> GetAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken));
    }
}
