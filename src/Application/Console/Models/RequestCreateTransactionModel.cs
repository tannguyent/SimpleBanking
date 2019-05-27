using System;

namespace SimpleBankingApp.Models
{
    public class RequestCreateTransactionModel
    {
        public Guid BankingAccountId { get; set; }

        public decimal Amount { get; set; }
    }
}
