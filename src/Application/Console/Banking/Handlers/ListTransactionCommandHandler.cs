using SimpleBankingApp.Banking.Commands;
using SimpleBankingApp.Print.Events;
using SimpleBankingApp.Services;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xer.Cqrs.CommandStack;
using Xer.Cqrs.EventStack;

namespace SimpleBankingApp.Banking.Handlers
{
    class ListTransactionCommandHandler : ICommandAsyncHandler<ListTransactionsCommand>
    {
        private readonly IBankingService bankingService;
        private readonly EventDelegator eventDelegator;

        public ListTransactionCommandHandler(IBankingService bankingService,EventDelegator eventDelegator)
        {
            this.bankingService = bankingService;
            this.eventDelegator = eventDelegator;
        }
        public async Task HandleAsync(ListTransactionsCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            // get data
            var data = await bankingService.GetTransactionsAsync(cancellationToken);

            // sent event to print 
            await eventDelegator.SendAsync(new ShowListTransactionEvent(data), cancellationToken);
        }
    }
}
