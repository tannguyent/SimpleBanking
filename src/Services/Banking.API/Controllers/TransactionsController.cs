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
    }
}
