using Banking.API.Infrastructure.Core;
using System;
using System.Collections.Generic;

namespace Banking.API.Infrastructure.Database.Models
{
    public class Transaction: AuditableEntity
    {
        public Guid BankingAccountId { get; set; }

        public decimal Amount { get; set; }

        public TransactionStatus Status { get; set; }

        public BankingAccount BankingAccount { get; set; }

        public ICollection<TransactionHistory> TransactionHistories { get; set; }
    }
}
