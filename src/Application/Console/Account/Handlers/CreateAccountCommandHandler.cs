using Microsoft.Extensions.Logging;
using SimpleBankingApp.Account.Commands;
using SimpleBankingApp.Services;
using System.Threading;
using System.Threading.Tasks;
using Xer.Cqrs.CommandStack;

namespace SimpleBankingApp.Account.Handlers
{
    public class CreateAccountCommandHandler : ICommandAsyncHandler<CreateAccountCommand>
    {
        private readonly ILogger<CreateAccountCommandHandler> _logger;
        private readonly IAccountService _accountService;
        private readonly IBankingService _bankingService;
        private readonly CommandDelegator _commandDelegator;

        public CreateAccountCommandHandler(
            ILogger<CreateAccountCommandHandler> logger,
            IAccountService accountService,
            IBankingService bankingService,
            CommandDelegator commandDelegator)
        {
            _logger = logger;
            _accountService = accountService;
            _bankingService = bankingService;
            _commandDelegator = commandDelegator;
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
            var userId = await _accountService.CreateAccountAsync(command, cancellationToken);

            _logger.LogInformation("CREATE ACCOUNT SUCCESS");
        }
    }
}
