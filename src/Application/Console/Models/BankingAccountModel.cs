using System;

namespace SimpleBankingApp.Models
{
    public class BankingAccountModel
    {
        public Guid UserId { get; set; }

        public decimal CurrentBalance { get; set; }

        public virtual Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }
    }
}
