using System;

namespace SimpleBankingApp.Banking.Commands
{
    public class CheckBalanceCommand
    {
        public CheckBalanceCommand(Guid debitAccountId)
        {
            DebitAccountId = debitAccountId;
        }

        public Guid DebitAccountId { get; }
    }
}
