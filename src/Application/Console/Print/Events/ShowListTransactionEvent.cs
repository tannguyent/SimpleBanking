using SimpleBankingApp.Models;
using System.Collections.Generic;

namespace SimpleBankingApp.Print.Events
{
    public class ShowListTransactionEvent
    {

        public ShowListTransactionEvent(List<TransactionModel> transactions)
        {
            Transactions = transactions;
        }

        public List<TransactionModel> Transactions { get; }
    }
}
