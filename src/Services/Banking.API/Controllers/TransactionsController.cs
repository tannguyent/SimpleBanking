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
    //[Authorize]
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
        public Task<List<TransactionModel>> Get(Guid accountId,CancellationToken cancellationToken = default(CancellationToken))
        {
            return transactionService.GetTransactionsAsync(accountId, cancellationToken);
        }

        [HttpPost("deposit")]
        public Task Deposit(RequestCreateTransactionModel model, CancellationToken cancellationToken = default(CancellationToken))
        {
            return  transactionService.RecordDepositTransactionAsync(model.BankingAccountId, model.Amount, cancellationToken);
        }

        [HttpPost("withdraw")]
        public Task WithDraw(RequestCreateTransactionModel model, CancellationToken cancellationToken = default(CancellationToken))
        {
            return transactionService.RecordWithdrawTransactionAsync(model.BankingAccountId, model.Amount, cancellationToken);
        }
    }
}
