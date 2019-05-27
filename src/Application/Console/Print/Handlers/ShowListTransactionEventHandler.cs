using SimpleBankingApp.Print.Events;
using System;
using Xer.Cqrs.EventStack;

namespace SimpleBankingApp.Print.Handlers
{
    class ShowListTransactionEventHandler : IEventHandler<ShowListTransactionEvent>
    {
        public void Handle(ShowListTransactionEvent @event)
        {
            Console.Clear();

            foreach (var transaction in @event.Transactions)
            {
                Console.WriteLine($"TransactionId:                  {transaction.Id}");
                Console.WriteLine($"    transaction Status:         {transaction.Status}");
                Console.WriteLine($"    transaction Amount:         {transaction.Amount}");
                Console.WriteLine($"    transaction CreatedDate:    {transaction.CreatedDate}");
            }

            Console.ReadLine();
        }
    }
}
