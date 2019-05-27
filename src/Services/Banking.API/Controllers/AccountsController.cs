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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet()]
        [Route("user/{userId}")]
        public Task<BankingAccountModel> GetByUserId(Guid userId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _accountService.GetByUserIdAsync(userId, cancellationToken);
        }

        // GET api/creaditbankings/5
        [HttpGet("{id}")]
        public Task<BankingAccountModel> Get(Guid id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _accountService.GetAsync(id, cancellationToken);
        }

        // POST api/creaditbankings
        [HttpPost]
        public Task<BankingAccountModel> Post(RequestCreateAccountModel accountModel, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _accountService.CreateAsync(accountModel, cancellationToken);
        }
    }
}
