using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Banking.API.Infrastructure.Service;
using Banking.API.Infrastructure.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Banking.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        [HttpGet]
        public Task<List<TransactionModel>> Get(Guid bankingAccountId,CancellationToken cancellationToken = default(CancellationToken))
        {
            return transactionService.GetTransactionsAsync(bankingAccountId, cancellationToken);
        }

        [HttpPost("deposit")]
        public Task<TransactionModel> Deposit(RequestCreateTransactionModel model, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        [HttpPost("withdraw")]
        public Task<TransactionModel> WithDraw(RequestCreateTransactionModel model, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
