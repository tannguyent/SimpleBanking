using System;

namespace SimpleBankingApp.Banking.Commands
{
    public class ListTransactionsCommand
    {
        public ListTransactionsCommand(Guid accountId)
        {
            AccountId = accountId;
        }

        public Guid AccountId { get; }
    }
}
