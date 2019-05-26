using System;
using System.Transactions;

namespace Banking.API.Infrastructure.Service.Models
{
    public class TransactionModel : BaseModel
    {
        public Guid BankingAccountId { get; set; }

        public decimal Amount { get; set; }

        public int Status { get; set; }
    }
}
