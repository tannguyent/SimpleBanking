using SimpleBankingApp.Banking.Commands;
using SimpleBankingApp.Print.Events;
using SimpleBankingApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xer.Cqrs.CommandStack;
using Xer.Cqrs.EventStack;

namespace SimpleBankingApp.Banking.Handlers
{
    public class CheckBalanceCommandHandler : ICommandAsyncHandler<CheckBalanceCommand>
    {
        private readonly IBankingService bankingService;
        private readonly EventDelegator eventDelegator;

        public CheckBalanceCommandHandler(IBankingService bankingService, EventDelegator eventDelegator)
        {
            this.bankingService = bankingService;
            this.eventDelegator = eventDelegator;
        }

        public async Task HandleAsync(CheckBalanceCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            var debitAccountInfo = await this.bankingService.GetBankingAccountAsync(command.DebitAccountId, cancellationToken);
            await eventDelegator.SendAsync(new ShowAccountDetailEvent(debitAccountInfo), cancellationToken);
        }
    }
}
