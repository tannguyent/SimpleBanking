using AutoMapper;
using Banking.API.Infrastructure.Database.Models;
using Banking.API.Infrastructure.Database.Repositories;
using Banking.API.Infrastructure.Service.Models;
using Banking.API.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Banking.API.Infrastructure.Service
{
    public interface IAccountService
    {
        Task<BankingAccountModel> CreateAsync(RequestCreateAccountModel model, CancellationToken cancellationToken = default(CancellationToken));

        Task<BankingAccountModel> GetByUserIdAsync(Guid accountId, CancellationToken cancellationToken = default(CancellationToken));

        Task<BankingAccountModel> GetAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken));
    }

    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;
        private readonly IMapper mapper;

        public AccountService(
            IAccountRepository accountRepository,
            IMapper mapper)
        {
            this.accountRepository = accountRepository;
            this.mapper = mapper;
        }

        public async Task<BankingAccountModel> CreateAsync(RequestCreateAccountModel model, CancellationToken cancellationToken = default(CancellationToken))
        {
            var entity = new BankingAccount()
            {
                CurrentBalance = 0,
                CreatedDate = DateTime.UtcNow,
                UserId = model.UserId
            };
            var account = await accountRepository.CreateAsync(entity, cancellationToken);
            return mapper.Map<BankingAccountModel>(account);
        }

        public async Task<BankingAccountModel> GetAsync(Guid accountId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return mapper.Map<BankingAccountModel>(await accountRepository.GetByIdAsync(accountId, cancellationToken));
        }

        public Task<BankingAccountModel> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default(CancellationToken))
        { 
            var account = accountRepository.GetAll().FirstOrDefault(c => c.UserId == userId);
            var model = mapper.Map<BankingAccountModel>(account);
            return Task.FromResult(model);
        }
    }
}
