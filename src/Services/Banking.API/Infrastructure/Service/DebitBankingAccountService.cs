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
    public interface IDebitBankingAccountService : IBankingAccountService { }

    public class DebitBankingAccountService : IDebitBankingAccountService
    {
        private readonly IDebitBankingAccountRepository debitBankingAccountRepository;
        private readonly IMapper mapper;

        public DebitBankingAccountService(
            IDebitBankingAccountRepository debitBankingAccountRepository, 
            IMapper mapper)
        {
            this.debitBankingAccountRepository = debitBankingAccountRepository;
            this.mapper = mapper;
        }

        public async Task<BankingAccountModel> CreateAsync(RequestCreateAccountModel model, CancellationToken cancellationToken = default(CancellationToken))
        {
            var entity = new DebitBankingAccount()
            {
                CurrentBalance = 0,
                CreatedDate = DateTime.UtcNow,
                UserId = model.UserId,
                Type = BankingAccountType.Debit
            };
            var account = await this.debitBankingAccountRepository.CreateAsync(entity, cancellationToken);
            return mapper.Map<BankingAccountModel>(account);
        }

        public async Task<BankingAccountModel> GetAsync(Guid accountId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return mapper.Map<BankingAccountModel>(await debitBankingAccountRepository.GetByIdAsync(accountId, cancellationToken));
        }

        public Task<BankingAccountModel> GetByAccountIdAsync(Guid accountId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var account = debitBankingAccountRepository.GetAll().FirstOrDefault(c => c.Type == BankingAccountType.Debit && c.UserId == accountId);
            var model = mapper.Map<BankingAccountModel>(account);
            return Task.FromResult(model);
        }
    }
}
