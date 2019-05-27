using SimpleBankingApp.Banking.Commands;
using SimpleBankingApp.Exceptions;
using SimpleBankingApp.Models;
using SimpleBankingApp.Print.Events;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xer.Cqrs.CommandStack;
using Xer.Cqrs.EventStack;

namespace SimpleBankingApp.Print.Handlers
{
    public class ShowRecordDepositScreenEventHandler : IEventAsyncHandler<ShowRecordDepositScreenEvent>
    {
        private readonly CommandDelegator _commandDelegator;
        private readonly ApplicationContext applicationContext;

        public ShowRecordDepositScreenEventHandler(CommandDelegator commandDelegator, ApplicationContext applicationContext)
        {
            _commandDelegator = commandDelegator;
            this.applicationContext = applicationContext;
        }

        public Task HandleAsync(ShowRecordDepositScreenEvent @event, CancellationToken cancellationToken = default(CancellationToken))
        {
            Console.Clear();

            Console.WriteLine("Create a DEBIT transaction");
            Console.Write("PLEASE INPUT AMOUNT:");
            var amountString = Console.ReadLine();
            decimal.TryParse(amountString, out decimal amount);
            if (amount < 0) throw new InputAmountInvalidException(amount);

            return _commandDelegator.SendAsync(new RecordDepositCommand(applicationContext.UserInfo.DebitAccountId, amount), cancellationToken);
        }
    }
}
