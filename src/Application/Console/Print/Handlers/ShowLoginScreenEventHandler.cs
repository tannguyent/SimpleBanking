using SimpleBankingApp.Account.Commands;
using SimpleBankingApp.Print.Events;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xer.Cqrs.CommandStack;
using Xer.Cqrs.EventStack;

namespace SimpleBankingApp.Print.Handlers
{
    public class ShowLoginScreenEventHandler : IEventAsyncHandler<ShowLoginScreenEvent>
    {
        public Task HandleAsync(ShowLoginScreenEvent @event, CancellationToken cancellationToken = default(CancellationToken))
        {
            Console.Clear();

            Console.WriteLine("1. Input UserName");
            var userName = Console.ReadLine();

            Console.WriteLine("2. Input password");
            var password = Console.ReadLine();

            return Task.CompletedTask;

        }
    }
}
