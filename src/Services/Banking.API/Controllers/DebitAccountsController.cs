using System;
using System.Threading;
using System.Threading.Tasks;
using Banking.API.Infrastructure.Service;
using Banking.API.Infrastructure.Service.Models;
using Banking.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Banking.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DebitAccountsController : ControllerBase
    {
        private readonly IDebitBankingAccountService _bankingAccountService;

        public DebitAccountsController(IDebitBankingAccountService bankingAccountService)
        {
            _bankingAccountService = bankingAccountService;
        }

        [HttpGet()]
        [Route("accountid/{accountid}")]
        public Task<BankingAccountModel> GetByAccountId(Guid accountid, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _bankingAccountService.GetByAccountIdAsync(accountid, cancellationToken);
        }

        // GET api/creaditbankings/5
        [HttpGet("{id}")]
        public Task<BankingAccountModel> Get(Guid id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _bankingAccountService.GetAsync(id, cancellationToken);
        }

        // POST api/creaditbankings
        [HttpPost]
        public Task<BankingAccountModel> Post(RequestCreateAccountModel accountModel, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _bankingAccountService.CreateAsync(accountModel, cancellationToken);
        }
    }
}
