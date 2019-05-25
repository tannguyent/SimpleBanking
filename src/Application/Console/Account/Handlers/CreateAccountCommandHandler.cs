using Microsoft.Extensions.Logging;
using SimpleBankingApp.Account.Commands;
using SimpleBankingApp.Account.Services;
using SimpleBankingApp.Models;
using SimpleBankingApp.Print.Events;
using System.Threading;
using System.Threading.Tasks;
using Xer.Cqrs.CommandStack;
using Xer.Cqrs.EventStack;

namespace SimpleBankingApp.Account.Handlers
{
    public class CreateAccountCommandHandler : ICommandAsyncHandler<CreateAccountCommand>
    {
        private readonly ILogger<CreateAccountCommandHandler> _logger;
        private readonly IAccountService _accountService;
        private readonly EventDelegator _eventDelegator;

        public CreateAccountCommandHandler(
            ILogger<CreateAccountCommandHandler> logger,
            IAccountService accountService,
            EventDelegator eventDelegator)
        {
            _logger = logger;
            _accountService = accountService;
            _eventDelegator = eventDelegator;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task HandleAsync(CreateAccountCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            _logger.LogInformation("START CREATE ACCOUNT ....");
            await _accountService.CreateAccountAsync(command, cancellationToken);

            _logger.LogInformation("START CREATE BANKING ....");

            _logger.LogInformation("START CREATE BANKING SUCCESS");
        }
    }
}
