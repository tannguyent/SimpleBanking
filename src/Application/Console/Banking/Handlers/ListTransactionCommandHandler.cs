using SimpleBankingApp.Bank.Services;
using SimpleBankingApp.Banking.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xer.Cqrs.CommandStack;

namespace SimpleBankingApp.Banking.Handlers
{
    class ListTransactionCommandHandler : ICommandAsyncHandler<ListTransactionsCommand>
    {
        private readonly IBankingService bankingService;

        public ListTransactionCommandHandler(IBankingService bankingService)
        {
            this.bankingService = bankingService;
        }
        public Task HandleAsync(ListTransactionsCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            // get data
            var data = bankingService.GetTransactionsAsync(cancellationToken);

            // sent event to print 
            return Task.CompletedTask;
        }
    }
}
