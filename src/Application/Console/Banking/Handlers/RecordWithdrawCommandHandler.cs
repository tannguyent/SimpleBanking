using SimpleBankingApp.Banking.Commands;
using SimpleBankingApp.Services;
using System.Threading;
using System.Threading.Tasks;
using Xer.Cqrs.CommandStack;
using Xer.Cqrs.EventStack;

namespace SimpleBankingApp.Banking.Handlers
{
    public class RecordWithdrawCommandHandler : ICommandAsyncHandler<RecordWithdrawCommand>
    {
        private readonly IBankingService bankingService;
        private readonly EventDelegator eventDelegator;

        public RecordWithdrawCommandHandler(IBankingService bankingService, EventDelegator eventDelegator)
        {
            this.bankingService = bankingService;
            this.eventDelegator = eventDelegator;
        }
        public Task HandleAsync(RecordWithdrawCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return bankingService.RecordWithdrawTransactionAsync(
                new Models.RequestCreateTransactionModel()
                {
                    BankingAccountId = command.DebitAccountId,
                    Amount = command.Amount
                },
                cancellationToken);
        }
    }
}
