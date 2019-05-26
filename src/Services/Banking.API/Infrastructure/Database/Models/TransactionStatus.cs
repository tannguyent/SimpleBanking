namespace Banking.API.Infrastructure.Database.Models
{
    public enum TransactionStatus
    {
        Create = 1,
        Pending = 2,
        Processing = 3,
        ProcessedSuccess = 4,
        ProcessedFail = 5,
    }
}
