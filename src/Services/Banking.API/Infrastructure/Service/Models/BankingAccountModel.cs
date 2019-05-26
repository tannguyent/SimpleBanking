using System;

namespace Banking.API.Infrastructure.Service.Models
{
    public class BankingAccountModel: BaseModel
    {
        public Guid UserId { get; set; }

        public decimal CurrentBalance { get; set; }
    }
}
