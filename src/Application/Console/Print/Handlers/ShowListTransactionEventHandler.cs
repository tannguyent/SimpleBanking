﻿using SimpleBankingApp.Print.Events;
using System;
using Xer.Cqrs.EventStack;

namespace SimpleBankingApp.Print.Handlers
{
    class ShowListTransactionEventHandler : IEventHandler<ShowListTransactionEvent>
    {
        public void Handle(ShowListTransactionEvent @event)
        {
            Console.Clear();

            Console.WriteLine("{transaction.Id}-{transaction.Status}-{transaction.Amount}-{transaction.CreatedDate}-{transaction.UpdatedDate}");

            foreach (var transaction in @event.Transactions)
            {
                Console.WriteLine($"{transaction.Id}-{transaction.Status}-{transaction.Amount}-{transaction.CreatedDate}-{transaction.UpdatedDate}");
            }

            Console.ReadLine();
        }
    }
}