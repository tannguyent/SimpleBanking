using SimpleBankingApp.Print.Events;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xer.Cqrs.EventStack;

namespace SimpleBankingApp.Print.Handlers
{
    public class ShowAccountDetailEventHandler : IEventHandler<ShowAccountDetailEvent>
    {
        public void Handle(ShowAccountDetailEvent @event)
        {
            Console.Clear();
            Console.WriteLine($"1. AccountId: {@event.AccountModel.Id}");
            Console.WriteLine($"2. CurrentBalance: {@event.AccountModel.CurrentBalance}");
            Console.WriteLine($"3. CreatedDate: {@event.AccountModel.CreatedDate}");

            Console.ReadKey();
        }
    }
}
