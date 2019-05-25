using SimpleBankingApp.Print.Events;
using System;
using Xer.Cqrs.EventStack;

namespace SimpleBankingApp.Print.Handlers
{
    public class ShowHomeScreenEventHandler : IEventHandler<ShowHomeScreenEvent>
    {
        public void Handle(ShowHomeScreenEvent @event)
        {
            Console.Clear();

            if (@event.IsLogin)
            {
                Console.WriteLine("3. Record a Deposit");
                Console.WriteLine("4. Record a Withdrawl");
                Console.WriteLine("5. Check Balance");
                Console.WriteLine("6. List Transactions");
                Console.WriteLine("7. Logout");
            }
            else
            {
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Login");
            }
            
        }
    }
}
