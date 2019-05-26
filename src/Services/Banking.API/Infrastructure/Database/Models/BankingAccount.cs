using Banking.API.Infrastructure.Core;
using System;
using System.Collections.Generic;

namespace Banking.API.Infrastructure.Database.Models
{
    public abstract class BankingAccount : AuditableEntity
    {
        public int UserId { get; set; }

        public decimal CurrentBalance { get; set; }

        public BankingAccountType Type { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
