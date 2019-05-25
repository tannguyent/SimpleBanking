using SimpleBankingApp.Account.Commands;
using SimpleBankingApp.Print.Events;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xer.Cqrs.CommandStack;
using Xer.Cqrs.EventStack;

namespace SimpleBankingApp.Print.Handlers
{
    public class ShowCreateAccountScreenEventHandler : IEventAsyncHandler<ShowCreateAccountScreenEvent>
    {
        private readonly CommandDelegator _commandDelegator;

        public ShowCreateAccountScreenEventHandler(CommandDelegator commandDelegator)
        {
            _commandDelegator = commandDelegator;
        }

        public Task HandleAsync(ShowCreateAccountScreenEvent @event, CancellationToken cancellationToken = default(CancellationToken))
        {
            Console.Clear();
            Console.WriteLine("1. Input Email");
            var email = Console.ReadLine();

            Console.WriteLine("1. Input UserName");
            var userName = Console.ReadLine();

            Console.WriteLine("1. Input password");
            var password = Console.ReadLine();

            return _commandDelegator.SendAsync(new CreateAccountCommand(userName, email, password));

        }
    }
}
