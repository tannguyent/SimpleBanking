using Banking.API.Infrastructure.Core;
using System;

namespace Banking.API.Infrastructure.Database.Models
{
    public class TransactionHistory : AuditableEntity
    {
        public Guid TransactionId { get; set; }

        public decimal Amount { get; set; }

        public string Note { get; set; }

        public TransactionStatus Status { get; set; }
    }
}
