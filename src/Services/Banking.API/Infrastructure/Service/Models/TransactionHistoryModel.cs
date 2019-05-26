using System;

namespace Banking.API.Infrastructure.Service.Models
{
    public class TransactionHistoryModel : BaseModel
    {
        public Guid TransactionId { get; set; }

        public decimal Amount { get; set; }

        public string Note { get; set; }
    }
}
