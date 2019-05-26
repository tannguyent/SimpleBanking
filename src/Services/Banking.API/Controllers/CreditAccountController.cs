using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Banking.API.Infrastructure.Service;
using Banking.API.Infrastructure.Service.Models;
using Banking.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Banking.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CreditAccountController : ControllerBase
    {
        private readonly ICreditBankingAccountService _bankingAccountService;

        public CreditAccountController(ICreditBankingAccountService bankingAccountService)
        {
            _bankingAccountService = bankingAccountService;
        }

        // GET api/creaditbankings/5
        [HttpGet("{id}")]
        public Task<BankingAccountModel> Get(Guid id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _bankingAccountService.GetByAccountIdAsync(id, cancellationToken);
        }

        // POST api/creaditbankings
        [HttpPost]
        public Task<BankingAccountModel> Post(RequestCreateAccountModel accountModel, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _bankingAccountService.CreateAsync(accountModel, cancellationToken);
        }
    }
}
