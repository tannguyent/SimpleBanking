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
        private readonly CommandDelegator _commandDelegator;

        public ShowLoginScreenEventHandler(CommandDelegator commandDelegator)
        {
            _commandDelegator = commandDelegator;
        }

        public Task HandleAsync(ShowLoginScreenEvent @event, CancellationToken cancellationToken = default(CancellationToken))
        {
            Console.Clear();

            Console.WriteLine("1. Input UserName");
            var userName = Console.ReadLine();

            Console.WriteLine("2. Input password");
            var password = Console.ReadLine();

            return _commandDelegator.SendAsync(new LoginCommand(userName, password), cancellationToken);
        }
    }
}
