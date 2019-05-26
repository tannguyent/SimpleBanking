using Banking.API.Infrastructure.Core;
using System;
using System.Collections.Generic;

namespace Banking.API.Infrastructure.Database.Models
{
    public class BankingAccount : AuditableEntity
    {
        public int UserId { get; set; }

        public decimal CurrentBalance { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
