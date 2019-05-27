using System;

namespace SimpleBankingApp.Banking.Commands
{
    public class RecordWithdrawCommand
    {
        public RecordWithdrawCommand(Guid debitAccountId, decimal amount)
        {
            DebitAccountId = debitAccountId;
            Amount = amount;
        }

        public Guid DebitAccountId { get; }
        public decimal Amount { get; }
    }
}
