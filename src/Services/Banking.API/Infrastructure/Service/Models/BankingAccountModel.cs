namespace Banking.API.Infrastructure.Service.Models
{
    public class BankingAccountModel: BaseModel
    {
        public int UserId { get; set; }

        public decimal CurrentBalance { get; set; }
    }
}
