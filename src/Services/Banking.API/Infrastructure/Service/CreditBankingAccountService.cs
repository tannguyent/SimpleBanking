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
    public interface ICreditBankingAccountService: IBankingAccountService { }

    public class CreditBankingAccountService : ICreditBankingAccountService
    {
        private readonly ICreditBankingAccountRepository creditBankingAccountRepository;
        private readonly IMapper mapper;

        public CreditBankingAccountService(
            ICreditBankingAccountRepository creditBankingAccountRepository,
            IMapper mapper)
        {
            this.creditBankingAccountRepository = creditBankingAccountRepository;
            this.mapper = mapper;
        }

        public async Task<BankingAccountModel> CreateAsync(RequestCreateAccountModel model, CancellationToken cancellationToken = default(CancellationToken))
        {
            var entity = new CreditBankingAccount()
            {
                CurrentBalance = 0,
                CreatedDate = DateTime.UtcNow,
                UserId = model.UserId,
                Type = BankingAccountType.Credit
            };
            var account = await creditBankingAccountRepository.CreateAsync(entity, cancellationToken);
            return mapper.Map<BankingAccountModel>(account);
        }

        public async Task<BankingAccountModel> GetAsync(Guid accountId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return mapper.Map<BankingAccountModel>(await creditBankingAccountRepository.GetByIdAsync(accountId, cancellationToken));
        }

        public Task<BankingAccountModel> GetByAccountIdAsync(Guid accountId, CancellationToken cancellationToken = default(CancellationToken))
        { 
            var account = creditBankingAccountRepository.GetAll().FirstOrDefault(c => c.Type == BankingAccountType.Credit && c.UserId == accountId);
            var model = mapper.Map<BankingAccountModel>(account);
            return Task.FromResult(model);
        }
    }
}
